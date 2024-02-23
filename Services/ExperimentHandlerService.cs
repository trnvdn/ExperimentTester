using ExperimentTester.Models;
using ExperimentTester.Models.Dto;
using ExperimentTester.Services.IServices;

namespace ExperimentTester.Services
{
    public class ExperimentHandlerService : IExperimentHandlerService
    {
        private readonly IExperimentService _experimentService;
        private readonly IParticipantService _experimentParticipantService;
        private readonly IAssociationService _associationService;
        private int _distributionPercentage;

        public ExperimentHandlerService(IExperimentService experimentService, IParticipantService experimentParticipantService, IAssociationService associationService)
        {
            _experimentService = experimentService;
            _experimentParticipantService = experimentParticipantService;
            _associationService = associationService;
        }

        public async Task<ExperimentResult> RunExperiment(Guid deviceToken, string xName)
        {
            var participant = await getParticipantByToken(deviceToken) ?? await insertParticipant(deviceToken);

            var experiment = await getExperimentByIdAndKey(participant.ParticipantID, xName) ?? await insertExperiment(participant, xName);

            return new ExperimentResult
            {
                Key = experiment.Key,
                Value = experiment.Value
            };
        }

        private async Task<ParticipantDto> getParticipantByToken(Guid deviceToken)
        {
            var participantResponse = await _experimentParticipantService.GetParticipantByDeviceTokenAsync(deviceToken);
            return participantResponse;
        }

        private async Task<ParticipantDto> insertParticipant(Guid deviceToken)
        {
            var participant = new ParticipantDto
            {
                DeviceToken = deviceToken,
                ParticipantID = Guid.NewGuid()
            };

            var participantResponse = await _experimentParticipantService.AddParticipantAsync(participant);
            return participantResponse ? participant : null;
        }

        private async Task<ExperimentDto> getExperimentByIdAndKey(Guid id, string key)
        {
            var experimentResponse = await _experimentService.GetExperimentByParticipantIdAndKeyAsync(id, key);
            return experimentResponse;
        }

        private async Task<ExperimentDto> insertExperiment(ParticipantDto participantDto, string key)
        {
            var value = getResult(participantDto.DeviceToken, key);

            var experiment = new ExperimentDto
            {
                ExperimentID = Guid.NewGuid(),
                Key = key,
                Value = value,
                DistributionPercentage = _distributionPercentage
            };

            var experimentAddResult = await _experimentService.AddExperimentAsync(experiment);
            if (experimentAddResult)
            {
                var associationResponse = await _associationService.InsertAsync(participantDto.ParticipantID, experiment.ExperimentID);
                if (associationResponse)
                {
                    return experiment;
                }
                else
                {
                    throw new Exception("Failed to create association");
                }
            }

            return null;
        }

        private string getResult(Guid deviceToken, string xName)
        {
            if (xName == "button_color")
            {
                var colors = new string[] { "#FF0000", "#00FF00", "#0000FF" };
                int randomNumber = Math.Abs(deviceToken.GetHashCode()) % colors.Length;
                return colors[randomNumber];
            }
            else if (xName == "price")
            {
                var prices = new string[] { "10", "20", "5", "50" };
                var randomPercent = new Random().Next(0, 100);

                _distributionPercentage = randomPercent;

                if (randomPercent <= 75) return prices[0];
                else if (randomPercent <= 85) return prices[1];
                else if (randomPercent <= 95) return prices[2];
                else return prices[3];
            }
            else
            {
                throw new Exception("Invalid experiment");
            }
        }
    }
}

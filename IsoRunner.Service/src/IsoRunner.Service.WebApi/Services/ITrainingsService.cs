using System.Collections.Generic;
using IsoRunner.Service.WebApi.DTOs;
using IsoRunner.Service.WebApi.Models;

namespace IsoRunner.Service.WebApi.Services
{
	public interface ITrainingsService
	{
		void AddTraining(User user, TrainingDTO trainingDTO);
		void RemoveTraining(User user, int trainingId);
		IEnumerable<Training> GetTrainings(User user);
	}
}

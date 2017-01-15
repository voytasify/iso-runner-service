using System.Collections.Generic;
using System.Linq;
using IsoRunner.Service.WebApi.DTOs;
using IsoRunner.Service.WebApi.Infrastructure;
using IsoRunner.Service.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IsoRunner.Service.WebApi.Services.Impl
{
	public class TrainingsService : ITrainingsService
	{
		private readonly IsoRunnerContext _context;

		public TrainingsService(IsoRunnerContext context)
		{
			_context = context;
		}

		public void AddTraining(User user, TrainingDTO trainingDTO)
		{
			var training = new Training
			{
				Date = trainingDTO.Date,
				Description = trainingDTO.Description,
				Distance = trainingDTO.Distance,
				Duration = trainingDTO.Duration,
				Temperature = trainingDTO.Temperature,
				WeatherConditions = trainingDTO.WeatherConditions,
				User = user
			};

			_context.Trainings.Add(training);
			_context.SaveChanges();
		}

		public void RemoveTraining(User user, int trainingId)
		{
			var training = _context.Trainings.Include(t => t.User)
				.FirstOrDefault(t => t.TrainingId == trainingId);
			if (training?.User.UserId != user.UserId)
				return;

			_context.Trainings.Remove(training);
			_context.SaveChanges();
		}

		public IEnumerable<Training> GetTrainings(User user)
		{
			var trainings = _context.Users.Include(u => u.Trainings)
				.First(u => u.UserId == user.UserId).Trainings
				.ToList();
			return trainings;
		}
	}
}

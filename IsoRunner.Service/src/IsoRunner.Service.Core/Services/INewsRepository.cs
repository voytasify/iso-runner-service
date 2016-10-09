using System.Collections.Generic;
using IsoRunner.Service.Data.Entities;

namespace IsoRunner.Service.Core.Services
{
	public interface INewsRepository
	{
		IEnumerable<IsoRunnerNews> GetNews();
	}
}

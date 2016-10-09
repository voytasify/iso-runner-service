using System;
using System.Collections.Generic;
using IsoRunner.Service.Data.Entities;
using IsoRunner.Service.Data.Enums;

namespace IsoRunner.Service.Core.Services.Stubs
{
	public class NewsRepositoryStub : INewsRepository
	{
		public IEnumerable<IsoRunnerNews> GetNews()
		{
			return new[]
			{
				new IsoRunnerNews
				{
					Id = Guid.NewGuid(),
					Date = DateTime.Now,
					Type = IsoRunnerNewsType.Competition,
					Title = "Bieg listopadowy w Gdyni",
					Description =
						"11 listopada znów pobiegniemy z okazji odzyskania przez Polskę niepodległości! W poprzednim Biegu i Marszu Niepodległości w Gdyni wzięło udział niemal 7000 uczestników! Wierzymy, że uda Wam się pobić kolejny rekord i w biegający sposób uczcić to wyjątkowe dla każdego Polaka święto!"
				},
				new IsoRunnerNews
				{
					Id = Guid.NewGuid(),
					Date = DateTime.Now.AddDays(-1),
					Type = IsoRunnerNewsType.Equipment,
					Title = "Czy grubaśne buty Hoka nadają się do biegania?",
					Description = "Swoją przygodę z butami Hoka One One zacząłem kilka lat temu, a była to wtedy całkowita nowość w Polsce. Pierwszą parę kupiła mi rodzina z USA ale obecnie sytuacja pod tym względem jest dużo lepsza, pojawił się nawet polski dystrybutor marki, firma Raven,  dzięki której otrzymałem model Mafate Speed do przetestowania.  Jest to efekt przejęcia tej niszowej dotąd francuskiej firmy w 2012 roku przez amerykańską Deckers Outdoor Corporation, która ma w swojej ofercie także takie światowe marki jak Teva czy UGG.  Z roku na rok nawet w Polsce widzę coraz więcej biegaczy w tych butach, a trzeba wiedzieć, że na niektórych biegach na świecie biegnie w nich nawet około 50% startujących. "
				},
				new IsoRunnerNews
				{
					Id = Guid.NewGuid(),
					Date = DateTime.Now.AddDays(-2),
					Type = IsoRunnerNewsType.Interview,
					Title = "Na treningu z Iwoną Lewandowską",
					Description = "Iwona Lewandowska, czołowa polska biegaczka długodystansowa, reprezentantka Polski w maratonie na Igrzyskach w RIO. Zajęła tam 21 miejsce (lepiej na Igrzyskach wypadała tylko Małgorzata Sobańska), osiągając dobry wynik 2:31:41 pomimo niełatwych warunków pogodowych."
				}
			};

		}
	}
}

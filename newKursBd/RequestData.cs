using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newKursBd
{
	static public class RequestData
	{
		static public string[] queryNames =
		{
			"Вывести все клубы определённого района", "Вывести всех собак определённий породы и клуба", "Вывести соревнования в определённый временной промежуток",
			"Вывести всех собак рожденных определённый временной промежуток", "Вывести всех участников у которых есть фото", 
			"Вывести количество участников, у которых нет фото",
			"Вывести количество награждённых собак и общую сумму денежного эквивалента", "Вывести количество участий одной собаки",
			"Вывести количество всех собак, в том числе по возрастам", "Вывести участников у которых взнос за участия больше определённой суммы",
			"Вывести всех собак у которых кличка начинается на определённую букву", "Вывести соревнования у которых количество зрителей меньше 1000",
			"Вывести все соревнования определённого города", "Вывести клубы, в которых состоит заданное количество собак",
			"Вывести количество наград определённого участника , причём чтобы сумма денежного эквивалента была больше определённого числа",
			"Вывести максимальный возраст собаки",
			"Объединить стоимость собак каждой породы со средней ценой собак определённой породы",
			"Вывести соревнования в которых участвовали собаки определенного хозяина", "Вывести участников всех городов кроме выбранного", 
			"Вывести собак с max и min ценой", "Определить топ клубы по количеству собак в них",
			"Выбрать 10 собак, которые занимали призовые места, посчитав общее число наград, в том числе сколько раз было первое место",
			"Определить средний возраст собак по каждому клубу ", "Количество собак в каждом районе города ",
			"Для выбранного соревнования определить количество собак и суммарную стоимость оплаты взносов их хозяевами"
		};

		static public string[][] queryColumnsNames =
		{
			new string[] {"id Клуба", "Название", "Адрес", "Телефон", "Год открытия", "Вступительный взнос", "№ лицензии", "Дата окончания лицензии"},
			new string[] {"id Собаки", "Кличка",  "ФИО хозяина", "Год рождения", "Цена"},
			new string[] { "id Соревнования", "Название", "Банк", "Город", "Место проведения", "Дата соревнования", "Взнос за участие", "Количество зрителей"},
			new string[] {"id Собаки", "Кличка", "ФИО хозяина", "Порода", "Клуб", "Год рождения", "Цена"},
			new string[] {"id Участника", "Кличка", "Фото", "Порода", "Название соревнования", "Дата соревнования"},
			new string[] {"Количество участников"},
			new string[] {"Количество собак", "Общая сумма"},
			new string[] {"Кличка", "Порода", "Количество участий"},
			new string[] {"Всего собак", "5 лет", "4 года", "3 года", "2 года", "1 год", "6 месяцев"},
			new string[] {"id Участника", "Кличка", "Порода", "Название соревнования", "Общая сумма взноса за участия"},
			new string[] {"id Собаки", "Кличка", "Порода"},
			new string[] {"id Соревнования", "Название соревнования", "Количество зрителей"},
			new string[] {"Название соревнования", "Город", "Дата проведения"},
			new string[] {"id Клуба", "Название клуба", "Количество собак" },
			new string[] {"id Участника", "Название соревнования", "Количество наград", "Общая сумма денежного эквивалента"},
			new string[] {"Максимальный возраст собаки"},
			new string[] {"Порода", "Кличка", "Цена"},
			new string[] { "Кличка", "Название соревнования", "Банк", "Расчётный счёт", "Город", "Место проведения", "Дата соревнования", "Взнос за участие", "Количество зрителей"},
			new string[] { "id Участника", "Кличка", "Порода", "Название соревнования", "Город"},
			new string[] {"Название клуба", "Цена"},
			new string[] { "id Клуба", "Название клуба", "Количество собак"},
			new string[] { "Кличка", "Количество наград", "Количество первых мест"},
			new string[] { "id Клуба", "Название клуба", "Средний возраст собак"},
			new string[] { "id Района", "Название района", "Количество собак"},			
			new string[] {"Название соревнования", "Количество собак", "Общаяя сумма взносов"},
		};

		static public string innerJoinWithForeignKey1 = "SELECT  club_id, club_name, address, " +
			"\"number\", year_opened, ent_fee, licences, end_licences " +
			"FROM club " +
			"INNER JOIN district ON club.district_id=district.district_id " +
			"WHERE club.district_id = {0}" +
			"ORDER BY club_name ASC ";

		static public string innerJoinWithForeignKey2 = "SELECT dog_id, nickname,   " +
			"concat (owner.surname, ' ', owner.name, ' ', owner.midname) ownerfullName, " +
			"year_birth, price " +
			"FROM dog " +
			"INNER JOIN owner ON  dog.owner_id=owner.owner_id " +
			"INNER JOIN breed ON dog.breed_id=breed.breed_id " +
			"INNER JOIN club ON dog.club_id= club.club_id " +
			"WHERE dog.breed_id = {0} AND dog.club_id = {1} " +
			"ORDER BY nickname ASC ";

		static public string innerJoinWithDate1 = "SELECT  competition_id, compet_name, bank.bank, city.city, " +
			"venue.venue, date_event, partic_fee, number_viewers " +
			"FROM competition " +
			"INNER JOIN bank ON competition.bank_id=bank.bank_id " +
			"INNER JOIN city ON competition.city_id=city.city_id " +
			"INNER JOIN venue ON competition.venue_id= venue.venue_id " +
			"WHERE date_event BETWEEN {0} AND {1} " +
			"ORDER BY date_event ASC ";

		static public string innerJoinWithDate2 = "SELECT dog_id, nickname, " +
			"concat (owner.surname, ' ', owner.name, ' ', owner.midname) ownerfullName, " +
			"breed.breed, club.club_name, year_birth, price " +
			"FROM dog " +
			"INNER JOIN owner ON  dog.owner_id=owner.owner_id " +
			"INNER JOIN breed ON dog.breed_id=breed.breed_id " +
			"INNER JOIN club ON dog.club_id= club.club_id " +
			"WHERE year_birth BETWEEN {0} AND {1} " +
			"ORDER BY year_birth ASC ";

		static public string leftJoin = "SELECT participant_id, dog.nickname, dog.foto, breed.breed,competition.compet_name, " +
			"competition.date_event FROM participation " +
			"LEFT OUTER JOIN dog ON participation.dog_id = dog.dog_id AND dog.foto IS NOT NULL " +
			"LEFT OUTER JOIN breed ON dog.breed_id= breed.breed_id " +
			"LEFT OUTER JOIN competition ON participation.competition_id= competition.competition_id " +
			"WHERE dog.nickname IS NOT NULL " +
			"ORDER BY dog.nickname ASC;";

		static public string rightJoin = "SELECT COUNT(participation.dog_id) FROM participation " +
			"RIGHT OUTER JOIN dog ON participation.dog_id = dog.dog_id AND dog.foto IS NULL";

		static public string queryOnQueryByLeftJoinPrinciple = "SELECT SUM(allcol.col), SUM(allcol.cash) FROM  " +
			"(SELECT COUNT(awarding.participant_id) AS col, SUM(award.cash_eq) AS cash FROM awarding " +
			"LEFT OUTER JOIN dog ON awarding.participant_id = dog.dog_id " +
			"LEFT OUTER JOIN award ON awarding.award_id = award.award_id " +
			") AS allcol	";

		static public string finalQueryWithoutCondition = "SELECT dog.nickname, breed.breed, " +
			"COUNT(participant_id) AS countPart FROM participation " +
			"INNER JOIN dog ON  participation.dog_id=dog.dog_id " +
			"INNER JOIN breed ON dog.breed_id=breed.breed_id " +
			"INNER JOIN club ON dog.club_id= club.club_id " +
			"GROUP BY dog.nickname, breed.breed " +
			"ORDER BY breed.breed ASC;";

		static public string totalIncluding = "SELECT COUNT(dog_id) AS alldog, " +
			"SUM(CASE WHEN CAST(date_part('year', current_date) AS integer) - year_birth< 6 " +
			"AND CAST(date_part('year', current_date) AS integer) - year_birth > 4 THEN 1 ELSE 0 END) " +
			"AS fiveyearsdog, " +
			"SUM (CASE WHEN CAST(date_part('year', current_date) AS integer) - year_birth < 5 " +
			"AND CAST(date_part('year', current_date) AS integer) - year_birth > 3 THEN 1 ELSE 0 END) " +
			"AS fouryearsdog, " +
			"SUM (CASE WHEN CAST(date_part('year', current_date) AS integer) - year_birth < 4 " +
			"AND CAST(date_part('year', current_date) AS integer) - year_birth > 2 THEN 1 ELSE 0 END) " +
			"AS threeyearsdog, " +
			"SUM (CASE WHEN CAST(date_part('year', current_date) AS integer) - year_birth < 3 " +
			"AND CAST(date_part('year', current_date) AS integer) - year_birth > 1 THEN 1 ELSE 0 END) " +
			"AS twoyearsdog, " +
			"SUM (CASE WHEN CAST(date_part('year', current_date) AS integer) - year_birth < 2 " +
			"AND CAST(date_part('year', current_date) AS integer) - year_birth > 0 THEN 1 ELSE 0 END) " +
			"AS oneyearsdog, " +
			"SUM (CASE WHEN CAST(date_part('year', current_date) AS integer) - year_birth < 1 " +
			"THEN 1 ELSE 0 END) AS sixmonthssdog FROM dog";

		static public string summaryQueriesWithConditionOnDataByValue = "SELECT participant_id, dog.nickname, " +
			"breed.breed, competition.compet_name, SUM(partic_fee) AS allparticfee FROM participation " +
			"INNER JOIN dog ON  participation.dog_id=dog.dog_id " +
			"INNER JOIN breed ON dog.breed_id=breed.breed_id " +
			"INNER JOIN competition ON participation.competition_id= competition.competition_id " +
			"WHERE partic_fee > {0} " +
			"GROUP BY participant_id, dog.nickname, breed.breed, competition.compet_name, competition.competition_id " +
			"ORDER BY dog.nickname ASC";
		
		static public string summaryQueriesWithConditionOnDataByMask = "SELECT dog_id, nickname, breed FROM dog_view " +
			"WHERE LOWER (nickname) LIKE LOWER ('{0}%') " +
			"GROUP BY dog_id, nickname, breed " +
			"ORDER BY nickname ASC";

		static public string summaryQueriesWithConditionOnDataByIndex = "SELECT competition_id, " +
			"compet_name, number_viewers " +
			"FROM competition " +
			"WHERE number_viewers<1000 " +
			"GROUP BY competition_id, compet_name, number_viewers " +
			"ORDER BY compet_name ASC";

		static public string summaryQueriesWithConditionOnDataWithoutIndex = "SELECT compet_name, city.city, date_event " +
			"FROM competition " +
			"INNER JOIN city ON  competition.city_id=city.city_id " +
			"WHERE competition.city_id = {0} " +
			"ORDER BY compet_name ASC";

		//static public string finalQueryWithConditionOnGroups = "SELECT  dog.club_id, club.club_name, COUNT(dog_id) FROM dog " +
		//	"INNER JOIN club ON dog.club_id = club.club_id " +
		//	"GROUP BY dog.club_id, club.club_name " +
		//	"ORDER BY dog.club_id ASC ";

		static public string finalQueryWithConditionOnGroups = "SELECT  dog.club_id, club.club_name, " +
			"COUNT(dog_id) FROM dog " +
			"INNER JOIN club ON dog.club_id = club.club_id " +
			"GROUP BY dog.club_id, club.club_name " +
			"HAVING COUNT(dog_id) = {0} " +
			"ORDER BY club.club_name ASC ";

		static public string finalQueryWithConditionOnDataAndGroups = "SELECT awarding.participant_id, " +
            "competition.compet_name, COUNT(award.award_id) AS countaward, SUM(award.cash_eq) AS sumcash " +
            " FROM awarding " +
            "INNER JOIN participation ON participation.participant_id=awarding.participant_id " +
            "INNER JOIN award ON awarding.award_id= award.award_id " +
            "INNER JOIN competition ON participation.competition_id= competition.competition_id " +
			"WHERE awarding.participant_id = {0} " +
            "GROUP BY awarding.participant_id, competition.compet_name " +
			"HAVING SUM(award.cash_eq) >= {1} " +
            "ORDER BY awarding.participant_id ASC ";

		static public string requestOnRequestBasedOnPrincipleOfFinalRequest = "SELECT " +
			"CAST(date_part('year', current_date) " +
			"AS INTEGER) - d as minYO " +
			"FROM(SELECT MIN(year_birth) as d FROM dog ) as a";

		static public string queryUsingUnion = "SELECT  breed.breed, nickname, price FROM dog " +
			"INNER JOIN breed ON dog.breed_id = breed.breed_id " +
			"GROUP BY breed.breed, nickname, price " +
			"UNION " +
			"SELECT breed.breed, 'Средняя стоимость', (round(avg(dog.price),2)) FROM dog " +
			"INNER JOIN breed ON dog.breed_id=breed.breed_id " +
			"GROUP BY breed.breed " +
			"ORDER BY breed, price, nickname ASC;";

		static public string queriesWithSubqueriesUsingIn = "SELECT dog.nickname as abc, competition.compet_name, " +
			"bank.bank, pay_account, city.city, venue.venue, date_event, partic_fee, number_viewers " +
			"FROM competition " +
			"INNER JOIN participation ON participation.competition_id = competition.competition_id " +
			"INNER JOIN dog ON participation.dog_id = dog.dog_id " +
			"INNER JOIN bank ON  competition.bank_id= bank.bank_id " +
			"INNER JOIN city ON  competition.city_id= city.city_id " +
			"INNER JOIN venue ON  competition.venue_id= venue.venue_id " +
			"WHERE dog.dog_id IN (SELECT dog_id FROM dog WHERE owner_id = {0}) " +
			"ORDER BY dog.nickname";

		static public string queriesWithSubqueriesUsingNotIn = "SELECT participant_id, dog.nickname, breed.breed, " +
			"competition.compet_name, city.city FROM participation " +
			"INNER JOIN dog ON  participation.dog_id=dog.dog_id " +
			"INNER JOIN breed ON dog.breed_id=breed.breed_id " +
			"INNER JOIN competition ON participation.competition_id= competition.competition_id " +
			"INNER JOIN city ON  competition.city_id= city.city_id " +
			"WHERE competition.city_id NOT IN (SELECT city_id FROM city WHERE city_id = {0}) " +
			"GROUP BY participant_id, dog.nickname, breed.breed, competition.compet_name, city.city, competition.competition_id " +
			"ORDER BY city.city ASC";

		static public string queriesWithSubqueriesUsingCase = "SELECT CASE " +
			"WHEN price = (SELECT MAX(price) FROM dog) " +
			"THEN(SELECT club.club_name FROM club WHERE club_id = " +
			"(SELECT dog.club_id FROM dog WHERE dog.dog_id= cl.dog_id)) " +
			"WHEN price = (SELECT MIN(price) FROM dog) " +
			"THEN(SELECT club.club_name FROM club WHERE club_id = " +
			"(SELECT dog.club_id FROM dog WHERE dog.dog_id= cl.dog_id)) " +
			"END cmb, price " +
			"FROM dog cl " +
			"ORDER BY cmb LIMIT 2";

		static public string queriesWithSubqueriesUsingWith = "WITH clubcoutdog AS " +
			"(SELECT  dog.club_id, club.club_name, COUNT(dog_id) AS countdog FROM dog " +
			"INNER JOIN club ON dog.club_id = club.club_id " +
			"GROUP BY dog.club_id, club.club_name), " +
			"topclub AS " +
			"(SELECT club_id FROM clubcoutdog " +
			"WHERE countdog > (SELECT MAX(countdog)*0.85 FROM clubcoutdog)) " +
			"SELECT clubcoutdog.club_id, clubcoutdog.club_name, countdog FROM clubcoutdog " +
			"WHERE clubcoutdog.club_id IN (SELECT club_id FROM topclub) " +
			"GROUP BY clubcoutdog.club_id, clubcoutdog.club_name, countdog " +
			"ORDER BY countdog DESC, clubcoutdog.club_name ";
		
		static public string specialQuery1 = "SELECT  dog.nickname,  COUNT(award.award_id) AS countaward, " +
			"SUM(CASE WHEN award.award_id = 1 THEN 1 ELSE 0 END) AS Iwin  FROM awarding " +
			"INNER JOIN participation ON participation.participant_id=awarding.participant_id " +
			"INNER JOIN award ON awarding.award_id=award.award_id " +
			"INNER JOIN competition ON participation.competition_id= competition.competition_id " +
			"INNER JOIN dog ON  participation.dog_id= dog.dog_id " +
			"GROUP BY  dog.nickname " +
			"ORDER BY Iwin DESC LIMIT 10 ";

		static public string specialQuery2_1 = "SELECT  dog.club_id, club.club_name,  " +
			"ROUND(avg(CAST(date_part('year', current_date) AS INTEGER) - " +
			"dog.year_birth ),1) AS avgagedog FROM dog  " +
			"INNER JOIN club ON dog.club_id = club.club_id " +
			"GROUP BY dog.club_id, club.club_name " +
			"ORDER BY avgagedog ASC";

		static public string specialQuery2_2 = "SELECT  DISTINCT club.district_id, district.district_name, " +
			"COUNT(dog_id) as countdog FROM dog " +
			"INNER JOIN club ON dog.club_id = club.club_id " +
			"INNER JOIN district ON club.district_id = district.district_id " +
			"GROUP BY club.district_id, district.district_name " +
			"ORDER BY countdog ASC";

		static public string specialQuery3 = "SELECT competition.compet_name, COUNT (dog.dog_id) as countdog, " +
			"SUM(partic_fee) as sumpfee FROM competition " +
			"INNER JOIN participation ON participation.competition_id = competition.competition_id " +
			"INNER JOIN dog ON participation.dog_id = dog.dog_id " +
			"WHERE competition.competition_id = {0}  " +
			"GROUP BY competition.compet_name " +
			"ORDER BY competition.compet_name ";

        static public string forDiagram1 = "SELECT  dog.club_id, club.club_name, COUNT(dog_id) FROM dog " +
            "INNER JOIN club ON dog.club_id = club.club_id " +
            "GROUP BY dog.club_id, club.club_name " +
            "ORDER BY dog.club_id ASC "; //was query number 13

    }
}

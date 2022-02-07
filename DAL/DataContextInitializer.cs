using System;
using System.Collections.Generic;
using System.Linq;
using TSI.Models;

namespace TSI.DAL
{
    public class DataContextInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Name = "Корчагин Петр Петрович",
                    Password = "admin666",
                    Email = "admin@mail.ru",
                    UserId = new Guid("d8c9ea9b-c836-4dde-8664-586eaa5d2c6e")
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            if (!context.Cars.Any())
            {
                context.Cars.AddRange(new List<Car>()
                {
                    new Car()
                    {
                        Mark = "ВАЗ 2113",
                        BodyType = "Купе",
                        Consumption = 8,
                        Drive = "Передний",
                        Engine = "Бензиновый",
                        Gears = 5,
                        Mileage = 100000,
                        Power = 77,
                        CarId = new Guid("41d39c6c-0fdd-4c54-ad1b-e06840a4363b"),
                        Photo = new Guid("41d39c6c-0fdd-4c54-ad1b-e06840a4363b"),
                        State = "Подержаный",
                        Price = 150000,
                        Transmission = "МКПП",
                        Year = 2010
                    },
                    new Car()
                    {
	                    Mark = "Skoda Octavia",
	                    BodyType = "Седан",
	                    Consumption = 7,
	                    Drive = "Передний",
	                    Engine = "Бензиновый",
	                    Gears = 6,
	                    Mileage = 0,
	                    Power = 150,
	                    CarId = new Guid("ef35d0b6-6f17-42ff-bdb4-0f5b5f71bfca"),
	                    Photo = new Guid("ef35d0b6-6f17-42ff-bdb4-0f5b5f71bfca"),
	                    State = "Новый",
	                    Price = 2500000,
	                    Transmission = "МКПП",
	                    Year = 2021
                    },
                });
                context.SaveChanges();
            }


            if (!context.Offices.Any())
            {
	            var office_1 = new Office()
	            {
		            OfficeId = new Guid("62c11b01-10e1-42ba-be1b-1f80ea46e4d9"),
		            City = "Самара",
		            Street = "Венцека",
		            Building = "14",
                    FullAddress = "г. Самара ул. Венцека д. 14"
                };

	            var office_2 = new Office()
	            {
		            OfficeId = new Guid("01dc5a94-7bba-41b9-853a-a3e595b16ce5"),
                    City = "Тольятти",
                    Street = "Ленина",
                    Building = "31",
                    FullAddress = "г. Тольятти ул. Ленина д. 31"
                };

	            context.Offices.Add(office_1);
	            context.Offices.Add(office_2);
	            context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
	            var order = new Order()
	            {
		            CreateDate = DateTime.Now,
		            OrderId = new Guid("3f07af08-3055-44c2-ad03-521f16017a44"),
		            Status = "Готов к выдаче в офисе продаж",
		            Total = 1000000,
                    OfficeId = new Guid("01dc5a94-7bba-41b9-853a-a3e595b16ce5"),
		            UserId = new Guid("d8c9ea9b-c836-4dde-8664-586eaa5d2c6e"),
	            };

                context.Orders.Add(order);
                context.SaveChanges();
            }

            if (!context.CarsOrdersConnectors.Any())
            {
	            var connector = new CarsOrdersConnector()
	            {
		            CarsOrdersConnectorId = new Guid("3c4531c4-b9d3-4283-a2e3-7534c6df4925"),
		            CarId = new Guid("ef35d0b6-6f17-42ff-bdb4-0f5b5f71bfca"),
		            OrderId = new Guid("3f07af08-3055-44c2-ad03-521f16017a44")
	            };

	            context.CarsOrdersConnectors.Add(connector);
	            context.SaveChanges();
            }
        }
    }
}

using EntityCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCF
{
	public class Seeds
	{
		public void seedMeSenpai()
		{
			var db = new CFContext();
			db.Add(new Doctor
			{
				FirstName = "Janusz",
				LastName = "Tracz",
				Email = "JanuszTracz@gmail.com"

			}) ;
			db.Add(new Doctor
			{
				FirstName = "Marzena",
				LastName = "Paw",
				Email = "MarzenaPaw@gmail.com"

			});
			db.Add(new Patient 
			{
				FirstName = "Michał",
				LastName = "Markiewicz",
				BirthDate = DateTime.Parse("11.12.1997")
				
			
			
			});
			db.Add(new Patient
			{
				FirstName = "Karola",
				LastName = "Cezar",
				BirthDate = DateTime.Parse("14.2.1992")



			});
			db.Add(new Medicament
			{
				Name = "Paracetamol",
				Description = "Na gorączke i takie tam",
				Type = "Cokolwiek tu powinno być napisane"



			});
			db.Add(new Medicament
			{

				Name = "Acodin",
				Description = "Placebo",
				Type = "Cokolwiek tu powinno być napisane"



			});
			db.Add(new Prescription
			{
				IdDoctor = 1,
				IdPatient = 1,
				Date = DateTime.Now,
				DueDate = DateTime.Parse("10.2.2021")

			}) ;
			db.Add(new Prescription
			{
				IdDoctor = 2,
				IdPatient = 2,
				Date = DateTime.Now,
				DueDate = DateTime.Parse("10.2.2021")

			});
			
			db.SaveChanges();

		}
	}
}

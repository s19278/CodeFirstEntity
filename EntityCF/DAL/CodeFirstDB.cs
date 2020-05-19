using EntityCF.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EntityCF.DAL
{
	public class CodeFirstDB : Controller, IDbService
	{
		static CodeFirstDB()
		{

		}

		public IActionResult AddDoctor(Doctor doc)
		{
			var db = new CFContext();
			db.Doctor.Add(new Doctor
			{
				IdDoctor = db.Doctor.Max(e => e.IdDoctor),
				FirstName = doc.FirstName,
				LastName = doc.LastName,
				Email = doc.Email		

			}) ;
			return Ok();
		}

		public IActionResult DeleteDoctor(int id)
		{
			var db = new CFContext();
			var doc = db.Doctor.Where(e => e.IdDoctor == id);
			if (!doc.Any()) {
				return NotFound("Nie ma takiego doktorka");
			}
			db.Doctor.Remove(doc.FirstOrDefault());
			return Ok();
		}

		public IActionResult GetDoctor(int id)
		{
			var db = new CFContext();
			var doc = db.Doctor.Where(e => e.IdDoctor == id);
			if (!doc.Any())
			{
				return NotFound("Nie ma takiego doktorka");
			}
			
			return Ok(doc.FirstOrDefault());
		}

		public IActionResult ModifyDoctor(Doctor doc)
		{
			var db = new CFContext();
			var dc = db.Doctor.Where(e => e.IdDoctor == doc.IdDoctor);
			if (!dc.Any())
			{
				return NotFound("Nie ma takiego doktorka");
			}
			if (doc.LastName != null)
			{
				dc.FirstOrDefault().LastName = doc.LastName;
			}
			if (doc.FirstName != null)
			{
				dc.FirstOrDefault().FirstName = doc.FirstName;
			}
			if (doc.Email != null)
			{
				dc.FirstOrDefault().Email = doc.Email;
			}
			
			db.SaveChanges();
			return Ok();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCF.Models
{
	public class Prescription_Medicament
	{
		public int IdMedicament { get; set; }
		public int IdPrescription { get; set; }
		public int Dose { get; set; }

		public string Details { get; set; }

		public virtual Medicament medicament { get; set; }
		public virtual Prescription prescription { get; set; }
	}
}

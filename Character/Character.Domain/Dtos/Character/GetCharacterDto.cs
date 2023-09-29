﻿using Character.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Domain.Dtos.Character
{
	public class GetCharacterDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = "Frodo";
		public int HitPoints { get; set; } = 100;
		public int Strength { get; set; } = 10;
		public int Defence { get; set; } = 10;
		public int Intelligence { get; set; } = 10;
		public RpgClass Class { get; set; } = RpgClass.Knight;
	}
}

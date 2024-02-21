using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using UnityEngine;
using Verse;

namespace Identity
{
    public class genderedStuff : DefModExtension
    {
        public bool isFeminine;
        public bool isMasculine;
        public float genderedStrength;
    }
    public class genderTraitFactors : DefModExtension
    {
        public double feminineDysFactor;
        public double masculineDysFactor;
        public double totalDysFactor = 1.0;
    }
}

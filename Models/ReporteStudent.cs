using System.Collections;
using System.Collections.Generic;

namespace DrawingPdf.Models
{
    public class ReporteStudent
    {
        public string DistritoRegional { get; set; } = "004 - Azua ";
        public string DistritoEducativo { get; set; } = "0303 Bani";
        public string CentroEducativo { get; set; } = "Centor Educativo Juan Pablo Duarte";

        public ICollection<Students> Students { get; set; } = new List<Students>
        {
            new Students()
            {
                Id =  1123  ,
                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
               new Students()
            {
                                   Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
                  new Students()
            {
                                      Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
                     new Students()
            {
                                         Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
                        new Students()
            {
                                            Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
                           new Students()
            {
                                               Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
                              new Students()
            {                Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
                                 new Students()
            {                Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
                                    new Students()
            {                Id =  1123  ,

                ConsecutiveAbsence = 4,
                FullName = "Niguel Angel",
                Grade = "Quito",
                Level = "Primario",
                Session = "A"
            },
        };

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Pulsation { get; set; }
        public void CalculatePulsation()
        {
            if (Gender.Equals("Male"))
            {
                Pulsation = (210 - Age) / 10f;
            }else if (Gender.Equals("Female"))
            {
                Pulsation = (220 - Age) / 10f;
            }
            else
            {
                Pulsation = 0;
            }
        }
    }
}

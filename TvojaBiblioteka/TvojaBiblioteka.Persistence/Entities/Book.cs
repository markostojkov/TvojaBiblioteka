using System;

namespace TvojaBiblioteka.Persistence.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime DatePublished { get; set; }

        public int ApplicationUserFk { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public override string ToString()
        {
            return $"{Name}    {DescrptionTruncated()}    {Author}    {DatePublished}";
        }

        public string DescrptionTruncated()
        {
            return Description.Length > 30 ? Description.Substring(0, 30) : Description;
        }
    }   
}

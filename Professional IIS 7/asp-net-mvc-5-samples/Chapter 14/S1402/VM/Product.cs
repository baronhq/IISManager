//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Professional_IIS_7.asp_net_mvc_5_samples.Chapter_14.S1402.VM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }
    
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Starring { get; set; }
        public string SupportingActors { get; set; }
        public string Director { get; set; }
        public string ScriptWriter { get; set; }
        public string ProductionCountry { get; set; }
        public string ProductionCompany { get; set; }
        public int ReleaseYear { get; set; }
        public string Language { get; set; }
        public int RunTime { get; set; }
        public decimal Price { get; set; }
        public string Story { get; set; }
        public string Poster { get; set; }
        public int Stock { get; set; }
        public string StoryAbstract { get; set; }
    
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
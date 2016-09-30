using System.ComponentModel.DataAnnotations;


namespace Cidean.GF.Api.Core.Domain
{


    public partial class Business
    {

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
      

    }
}

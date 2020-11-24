using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class RepresentanteLegal
    {
        public string IdReprLegal { get; set; }
        public string NombresRepresentanteLegal { get; set; }
        public string ApellidosRepresentanteLegal { get; set; }
        public int IdTipoDocumento { get; set; }
        public int NoDocumento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
    }
}

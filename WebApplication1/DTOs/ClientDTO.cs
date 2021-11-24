using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.MS.CLIENT.DTOs
{
    public class ClientDTO
    {
        public int id_cliente { get; set; }

        public int id_tipocliente { get; set; }

        public int id_tipodocumento { get; set; }

        public int id_ubigeo { get; set; }

        public string st_email { get; set; }

        public string st_nombres { get; set; }

        public string st_apellidopaterno { get; set; }

        public string st_apellidomaterno { get; set; }

        public string st_numerodocumento { get; set; }

        public string st_codigoCavalSivOnline { get; set; }

        public string st_celular { get; set; }

        public string st_telefonofijo { get; set; }

        public string st_direccion { get; set; }

        public bool fg_aceptopoliticasuso { get; set; }

        public bool fg_autorizausodatospersonales { get; set; }

        public bool fg_personapep { get; set; }

        public string st_pep_instituciontrabajo { get; set; }

        public string st_pep_puesto { get; set; }

        public string st_key { get; set; }

    }
}

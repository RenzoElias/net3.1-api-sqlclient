using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using API.MS.CLIENT.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.MS.CLIENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public JsonResult Post(ClientDTO cliente)
        {
            string query = @"
                            SPDVM_INS_CLIENTE
                            @xid_cliente,
                            @xid_tipocliente,
                            @xid_tipodocumento,
                            @xid_ubigeo,
                            @xst_email,
                            @xst_nombres,
                            @xst_apellidopaterno,
                            @xst_apellidomaterno,
                            @xst_numerodocumento,
                            @xst_codigoCavalSivOnline,
                            @xst_celular,
                            @xst_telefonofijo,
                            @xst_direccion,
                            @xfg_aceptopoliticasuso,
                            @xfg_autorizausodatospersonales,
                            @xfg_personapep,
                            @xst_pep_instituciontrabajo,
                            @xst_pep_puesto,
                            @xst_key
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@xid_cliente", cliente.id_cliente);
                    myCommand.Parameters.AddWithValue("@xid_tipocliente", cliente.id_tipocliente);
                    myCommand.Parameters.AddWithValue("@xid_tipodocumento", cliente.id_tipodocumento);
                    myCommand.Parameters.AddWithValue("@xid_ubigeo", cliente.id_ubigeo);
                    myCommand.Parameters.AddWithValue("@xst_email", cliente.st_email);
                    myCommand.Parameters.AddWithValue("@xst_nombres", cliente.st_nombres);
                    myCommand.Parameters.AddWithValue("@xst_apellidopaterno", cliente.st_apellidopaterno);
                    myCommand.Parameters.AddWithValue("@xst_apellidomaterno", cliente.st_apellidomaterno);
                    myCommand.Parameters.AddWithValue("@xst_numerodocumento", cliente.st_numerodocumento);
                    myCommand.Parameters.AddWithValue("@xst_codigoCavalSivOnline", cliente.st_codigoCavalSivOnline);
                    myCommand.Parameters.AddWithValue("@xst_celular", cliente.st_celular);
                    myCommand.Parameters.AddWithValue("@xst_telefonofijo", cliente.st_telefonofijo);
                    myCommand.Parameters.AddWithValue("@xst_direccion", cliente.st_direccion);
                    myCommand.Parameters.AddWithValue("@xfg_aceptopoliticasuso", cliente.fg_aceptopoliticasuso);
                    myCommand.Parameters.AddWithValue("@xfg_autorizausodatospersonales", cliente.fg_autorizausodatospersonales);
                    myCommand.Parameters.AddWithValue("@xfg_personapep", cliente.fg_personapep);
                    myCommand.Parameters.AddWithValue("@xst_pep_instituciontrabajo", cliente.st_pep_instituciontrabajo);
                    myCommand.Parameters.AddWithValue("@xst_pep_puesto", cliente.st_pep_puesto);
                    myCommand.Parameters.AddWithValue("@xst_key", cliente.st_key);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
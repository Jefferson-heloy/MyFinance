using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class ContaModel
    {
        public int Id{ get; set; }

        [Required (ErrorMessage ="Informe o Nome do Banco")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Informe o Saldo da Conta")]
        public double Saldo { get; set; }
        public int Usuario_Id { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public ContaModel() { }
        //Recebe o contexto para acesso ás variaveis de sessão
        public ContaModel(IHttpContextAccessor httpContextAccessor) {
            HttpContextAccessor = httpContextAccessor;
        }
        private string IdUsuarioLogado() { return HttpContextAccessor.HttpContext.Session.GetString("IdNomeUsuarioLogado"); }
        public List<ContaModel> ListaConta()
        {
            List<ContaModel> lista = new List<ContaModel>();
            ContaModel item;

            
            string sql = $"SELECT ID,NOME,SALDO,USUARIO_ID FROM CONTA WHERE USUARIO_ID={IdUsuarioLogado()}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ContaModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.Saldo = double.Parse(dt.Rows[i]["SALDO"].ToString());
                item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                lista.Add(item);
            }
            return lista;
        }

        public void Insert()
        {
            
            string sql = $"INSERT INTO CONTA (NOME,SALDO,USUARIO_ID) VALUES ('{Nome}','{Saldo}','{IdUsuarioLogado()}')";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
        }
        public void Excluir(int id_conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM CONTA WHERE ID=" + id_conta);
        }

    }
}

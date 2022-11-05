﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App01
{
    class Pessoa
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }

        public string endereco { get; set; }

        public string celular { get; set; }

        public string email { get; set; }

        public string data { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\source\repos\App01\DbPessoa.mdf;Integrated Security=True");

        public List<Pessoa> listapessoa()
        {
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM Pessoa";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa p = new Pessoa();
                p.Id = (int)dr["Id"];
                p.nome = dr["nome"].ToString();
                p.cidade = dr["cidade"].ToString();
                p.endereco = dr["endereco"].ToString();
                p.celular = dr["celular"].ToString();
                p.email = dr["email"].ToString();
                p.data = dr["data"].ToString();
                li.Add(p);

            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string cidade, string endereco, string celular, string email, string data)
        {
            string sql = "INSERT INTO Pessoa(nome,cidade,endereco,celular,email,data) VALUES ('"+nome+"','"+cidade+ "','" + endereco + "','" + celular+ "','" + email + "','" + data + "')";
                con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Atualizar(int Id, string nome, string cidade, string endereco, string celular, string email, string data)
        {
            string sql = "UPDATE Pessoa SET nome='"+nome+"',cidade='"+cidade+ "',endereco='" + endereco + "',celular='" + celular + "',email='" + email + "',data='" + data + "' WHERE Id='" + Id+"'";
                con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Pessoa WHERE Id='"+Id+"'";
                con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Pessoa WHERE Id='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cidade = dr["cidade"].ToString();
                endereco = dr["endereco"].ToString();
                celular= dr["celular"].ToString();
                email = dr["email"].ToString();
                data = dr["data"].ToString();
            }

            dr.Close();
            con.Close();
        }

        internal void Atualizar()
        {
            throw new NotImplementedException();
        }
    }
}

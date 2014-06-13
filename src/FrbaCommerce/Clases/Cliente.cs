using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excepciones;
using Conexion;

namespace Clases
{
    public class Cliente : Base
    {
        List<SqlParameter> parameterList = new List<SqlParameter>();
    
        #region atributos
        private int _id_Cliente;
        private string _Tipo_Dni;
        private int _Dni;
        private string _Cuil;
        private string _Apellido;
        private string _Nombre;
        private DateTime _Fecha_nac;
        private string _Mail;
        private string _Telefono;
        private string _Dom_calle;
        private int _Dom_nro_calle;
        private int _Dom_piso;
        private string _Dom_depto;
        private string _Dom_cod_postal;
        private bool _Activo;
        private decimal _Reputacion;

        private Usuario _usuario;
        #endregion

        #region properties
        public int id_Cliente
        {
            get { return _id_Cliente; }
            set { _id_Cliente = value; }
        }
        public string Tipo_Dni
        {
            get { return _Tipo_Dni; }
            set { _Tipo_Dni = value; }
        }
        public int Dni
        {
            get { return _Dni; }
            set { _Dni = value; }
        }
        public string Cuil
        {
            get { return _Cuil; }
            set { _Cuil = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public DateTime Fecha_nac
        {
            get { return _Fecha_nac; }
            set { _Fecha_nac = value; }
        }
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Dom_calle
        {
            get { return _Dom_calle; }
            set { _Dom_calle = value; }
        }
        public int Dom_nro_calle
        {
            get { return _Dom_nro_calle; }
            set { _Dom_nro_calle = value; }
        }
        public int Dom_piso
        {
            get { return _Dom_piso; }
            set { _Dom_piso = value; }
        }
        public string Dom_depto
        {
            get { return _Dom_depto; }
            set { _Dom_depto = value; }
        }
        public string Dom_cod_postal
        {
            get { return _Dom_cod_postal; }
            set { _Dom_cod_postal = value; }
        }
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }
        public decimal Reputacion
        {
            get { return _Reputacion; }
            set { _Reputacion = value; }
        }        
        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        #endregion

        #region constructor
        public Cliente()
        {
        }
        public Cliente(int unIdCliente){
            this.id_Cliente = unIdCliente;
            

        }
        public Cliente(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail){
            this.Apellido = unApellido;
            this.Nombre = unNombre;
            this.Tipo_Dni = unTipoDni;
            this.Dni = unDni;
            this.Mail = unMail;
        }

        #endregion

        #region metodos publicos
        public override string NombreTabla()
        {
            return "Clientes";
        }

        public override string NombreEntidad()
        {
            return "Cliente";
        }

        public override void DataRowToObject(DataRow dr)
        {
            // Esto es tal cual lo devuelve el stored de la DB
            this.id_Cliente = Convert.ToInt32(dr["id_Cliente"]);
            this.Tipo_Dni = dr["Tipo_Dni"].ToString();
            this.Dni = Convert.ToInt32(dr["Dni"]);
            this.Cuil = dr["Cuil"].ToString();
            this.Apellido = dr["Apellido"].ToString();
            this.Nombre = dr["Nombre"].ToString();
            this.Fecha_nac = Convert.ToDateTime(dr["Fecha_nac"]);
            this.Mail = dr["Mail"].ToString();
            this.Telefono = dr["Telefono"].ToString();
            this.Dom_calle = dr["Dom_calle"].ToString();
            this.Dom_nro_calle = Convert.ToInt32(dr["Dom_nro_calle"]);
            this.Dom_piso = Convert.ToInt32(dr["Dom_piso"]);
            this.Dom_depto = dr["Dom_depto"].ToString();
            this.Dom_cod_postal = dr["Dom_cod_postal"].ToString();
            this.Activo = Convert.ToBoolean(dr["Activo"]);
            this.usuario = new Usuario();
            //this.usuario.Id_Usuario = Convert.ToInt32(dr["id_Usuario"]);
            this.Reputacion = Convert.ToDecimal(dr["Reputacion"]);
        }
 public void CargarObjetoClienteConId()
        {
            setearListaDeParametrosConIdCliente();
            DataSet ds = SQLHelper.ExecuteDataSet("traerClienteConId", CommandType.StoredProcedure, parameterList);
            parameterList.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRowToObject(ds.Tables[0].Rows[0]);
            }
        }

        public static DataSet obtenerTodosLosClientes()
        {
            Cliente unCliente = new Cliente();
            return unCliente.TraerListado(unCliente.parameterList, "");
        }

        public static DataSet obtenerTodosLosClientesConFiltros(string unNombre, string unApellido, string unTipoDni, int unDni, string unMail)
        {
            Cliente unCliente = new Cliente(unNombre, unApellido, unTipoDni, unDni, unMail);
            unCliente.setearListaDeParametrosConFiltros(unCliente.Nombre, unCliente.Apellido, unCliente.Tipo_Dni, unCliente.Dni, unCliente.Mail);
            DataSet ds = unCliente.TraerListado(unCliente.parameterList, "ConFiltros");
            unCliente.parameterList.Clear();
            return ds;
        }
       
        public void guardarDatosDeClienteNuevo()
        {
            this.usuario.Id_Usuario = this.usuario.GuardarYObtenerID();
            setearListaDeParametros();
            setearListaDeParametrosConIdUsuario(this.usuario.Id_Usuario);
            this.Guardar(parameterList);            
            parameterList.Clear();
            
            //if (dsNuevaEmpresa.Tables[0].Rows.Count > 0)
            //{
            //    this.id_Empresa = Convert.ToInt32(dsNuevaEmpresa.Tables[0].Rows[0]["id_Empresa"]);
            //} CREO QUE NO LO NECESITO
            //{
            //    throw new BadInsertException();
            //}
        }
        
        public void ModificarDatos()
        {
            setearListaDeParametrosConIdCliente();
            setearListaDeParametros();            
            if (this.Modificar(parameterList))
            {
                parameterList.Clear();
            }
           
        }

        public void Desactivar()
        {
            setearListaDeParametrosConIdCliente();
            this.Deshabilitar(parameterList);
            parameterList.Clear();
            
        }

        #endregion

        #region metodos privados
        private void setearListaDeParametrosConFiltros(string Nombre, string Apellido, string TipoDni, int Dni, string Mail)
        {
            parameterList.Add(new SqlParameter("@Nombre", Nombre));
            parameterList.Add(new SqlParameter("@Apellido", Apellido));
            parameterList.Add(new SqlParameter("@Tipo_Dni", TipoDni));
            parameterList.Add(new SqlParameter("@Dni", Dni)); 
            parameterList.Add(new SqlParameter("@Mail", Mail)); 
        }
        private void setearListaDeParametrosConIdUsuario(int id_Usuario)
        {
            parameterList.Add(new SqlParameter("@id_Usuario", id_Usuario));
        }

        private void setearListaDeParametrosConIdCliente()
        {
            parameterList.Add(new SqlParameter("@id_Cliente", this.id_Cliente));
        }
        //private void setearListaDeParametrosConIdYFiltros(string Nombre, string Apellido, string TipoDni, int Dni, string Mail)
        //{
        //    parameterList.Add(new SqlParameter("@id_Cliente", this.id_Cliente));
        //    parameterList.Add(new SqlParameter("@Nombre", Nombre));
        //    parameterList.Add(new SqlParameter("@Apellido", Apellido));
        //    parameterList.Add(new SqlParameter("@Tipo_Dni", TipoDni));
        //    parameterList.Add(new SqlParameter("@Dni", Dni));
        //    parameterList.Add(new SqlParameter("@Mail", Mail)); 
        //}
        private void setearListaDeParametros()
        {
            //parameterList.Add(new SqlParameter("@id_Cliente", this.id_Cliente));
            parameterList.Add(new SqlParameter("@Tipo_Dni", this.Tipo_Dni));
            parameterList.Add(new SqlParameter("@Dni", this.Dni));
            parameterList.Add(new SqlParameter("@Cuil", this.Cuil));
            parameterList.Add(new SqlParameter("@Apellido", this.Apellido));
            parameterList.Add(new SqlParameter("@Nombre", this.Nombre));
            parameterList.Add(new SqlParameter("@Mail", this.Mail));
            parameterList.Add(new SqlParameter("@Fecha_nac", this.Fecha_nac));
            parameterList.Add(new SqlParameter("@Telefono", this.Telefono));
            parameterList.Add(new SqlParameter("@Dom_calle", this.Dom_calle));
            parameterList.Add(new SqlParameter("@Dom_nro_calle", this.Dom_nro_calle));
            parameterList.Add(new SqlParameter("@Dom_piso", this.Dom_piso));
            parameterList.Add(new SqlParameter("@Dom_depto", this.Dom_depto));
            parameterList.Add(new SqlParameter("@Dom_cod_postal", this.Dom_cod_postal));
            //parameterList.Add(new SqlParameter("@Dom_ciudad", this.Dom_ciudad));
            parameterList.Add(new SqlParameter("@Activo", this.Activo));       
        }
        
        
        #endregion

    }
}

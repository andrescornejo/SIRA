﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atestados.Datos.Modelo;
using Atestados.Objectos;
using Atestados.Objetos;
using Atestados.Objetos.Dtos;
using AutoMapper;
using BCrypt;

namespace Atestados.Negocios.Negocios
{
    public class InformacionGeneral
    {
        private AtestadosEntities db = new AtestadosEntities();

        #region Persona
        public PersonaDTO CargarPersona(int? id)
        {
            Persona persona = db.Persona.Find(id);

            if (persona == null)
                return null;

            PersonaDTO personasDto = Mapper.Map<Persona, PersonaDTO>(persona);

            return personasDto;

        }

        public Persona CargarPersonaParaEditar(int? id)
        {
            Persona persona = db.Persona.Find(id);

            if (persona == null)
                return null;

            return persona;

        }

        public Persona CargarPersonaParaBorrar(int? id)
        {
            Persona persona = db.Persona.Find(id);

            if (persona == null)
                return null;

            return persona;

        }

        public List<PersonaDTO> CargarPersonas()
        {

            List<Persona> listaPersona = db.Persona.ToList();

            List<PersonaDTO> listaPersonasDto = Mapper.Map<List<Persona>, List<PersonaDTO>>(listaPersona);

            return listaPersonasDto;

        }

        public void GuardarPersona(Persona persona)
        {
            db.Persona.Add(persona);
            db.SaveChanges();
        }

        public void EditarPersona(Persona persona)
        {
            Usuario usuario = db.Usuario.Where(x => x.UsuarioID == persona.PersonaID).FirstOrDefault();
            usuario.Email = persona.Email; //Asegurar que los correos son iguales.
            db.Entry(usuario).State = EntityState.Modified;
            db.Entry(persona).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void BorrarPersona(int id)
        {
            Persona persona = db.Persona.Find(id);

            // TODO revisar integridad referencial en <1 - base.sql> 
            // Actualmente no hay acción para ON DELETE, eso previene que las entidades se puedan borrar

            //db.Persona.Remove(persona);
            //db.SaveChanges();
        }
        #endregion

        #region Usuario

        public List<UsuarioDTO> ObtenerUsuarios(int id)
        {
            List<Persona> personas = db.Persona.Where(x => x.Usuario != null && x.PersonaID != id && x.esActivo == true).ToList();
            List<UsuarioDTO> usuarios = Mapper.Map<List<Persona>, List<UsuarioDTO>>(personas);
            for (int i = 0; i < usuarios.Count; i++)
            {
                usuarios[i] = Mapper.Map(personas[i].Usuario, usuarios[i]);
            }
            return usuarios;
        }

        public UsuarioDTO UsuarioPorEmail(string email)
        {
            Persona persona = db.Persona.Where(x => x.Email == email && x.Usuario != null).FirstOrDefault();
            if (persona != null)
            {
                UsuarioDTO usuarioDTO = AutoMapper.Mapper.Map<Persona, UsuarioDTO>(persona);
                return AutoMapper.Mapper.Map(persona.Usuario, usuarioDTO);
            }
            return null;
        }

        public void CrearUsuario(UsuarioDTO usuario)
        {
            // Se consigue la categoría por defecto para todas las personas. (Sin Categoría)
            int tipoCategoria = TiposHelper.ObtenerTipoCategoriaID("Sin Categoría");

            // Se consigue el tipo de un usuario nuevo por defecto. (Docente)
            int tipoUsuario = TiposHelper.ObtenerTipoUsuarioID("Docente");

            Usuario u = Mapper.Map<UsuarioDTO, Usuario>(usuario);
            u.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
            Persona persona = Mapper.Map<UsuarioDTO, Persona>(usuario);
            persona.TipoUsuario = tipoUsuario;
            persona.CategoriaActual = tipoCategoria;
            persona.esActivo = true;
            GuardarPersona(persona);
            u.UsuarioID = persona.PersonaID;
            u.esActivo = true;

            db.Usuario.Add(u);
            db.SaveChanges();
        }

        public bool ValidarUsuario(string email, string contrasena)
        {
            Persona persona = db.Persona.Where(x => x.Email == email && x.Usuario != null).FirstOrDefault();
            if (persona != null)
                return BCrypt.Net.BCrypt.Verify(contrasena, persona.Usuario.Contrasena);
            else
                return false;
        }

        #endregion

    }
}

﻿using GestordeTaras.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.DAL
{
    public class EstadoTareaDAL
    {
        // Método para crear un nuevo estado de tarea en la base de datos de forma asincrónica.
        public static async Task<int> CreateAsync(EstadoTareaEN estadoTarea)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                // Agrega el estado de tarea al DbSet correspondiente en el contexto.
                dbContext.Add(estadoTarea);
                // Guarda los cambios en la base de datos.
                await dbContext.SaveChangesAsync();
            }
            // Retorna el resultado (podría ser el ID del estado de tarea recién creado, por ejemplo).
            return result;
        }

        // Método para actualizar un estado de tarea existente en la base de datos de forma asincrónica.
        public static async Task<int> UpdateAsync(EstadoTareaEN estadoTarea)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                // Busca el estado de tarea existente por su ID.
                var estadoTareaDB = await dbContext.EstadoTareaEN.FirstOrDefaultAsync(e => e.Id == estadoTarea.Id);
                if (estadoTareaDB != null)
                {
                    // Actualiza las propiedades del estado de tarea con los nuevos valores.
                    estadoTareaDB.Nombre = estadoTarea.Nombre;

                    // Marca el estado de tarea como modificado en el contexto.
                    dbContext.Update(estadoTareaDB);
                    // Guarda los cambios en la base de datos.
                    result = await dbContext.SaveChangesAsync();
                }
                // Retorna el resultado (número de filas afectadas en la base de datos).
                return result;
            }
        }

        // Método para eliminar un estado de tarea de la base de datos de forma asincrónica.
        public static async Task<int> DeleteAsync(EstadoTareaEN estadoTarea)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                // Busca el estado de tarea existente por su ID.
                var estadoTareaDB = await dbContext.EstadoTareaEN.FirstOrDefaultAsync(e => e.Id == estadoTarea.Id);
                if (estadoTareaDB != null)
                {
                    // Elimina el estado de tarea del DbSet correspondiente en el contexto.
                    dbContext.EstadoTareaEN.Remove(estadoTareaDB);
                    // Guarda los cambios en la base de datos.
                    result = await dbContext.SaveChangesAsync();
                }
            }
            // Retorna el resultado (número de filas afectadas en la base de datos).
            return result;
        }

        // Método para obtener un estado de tarea por su ID de forma asincrónica.
        public static async Task<EstadoTareaEN> GetByIdAsync(EstadoTareaEN estadoTarea)
        {
            var estadoTareaDB = new EstadoTareaEN();
            using (var dbContext = new ContextoBD())
            {
                // Busca el estado de tarea por su ID y asigna el resultado a la variable estadoTareaDB.
                estadoTareaDB = await dbContext.EstadoTareaEN.FirstOrDefaultAsync(e => e.Id == estadoTarea.Id);
            }
            // Retorna el estado de tarea encontrado.
            return estadoTareaDB;
        }

        // Método para obtener todos los estados de tarea de la base de datos de forma asincrónica.
        public static async Task<List<EstadoTareaEN>> GetAllAsync()
        {
            var estadoTareas = new List<EstadoTareaEN>();
            using (var bdContexto = new ContextoBD())
            {
                // Obtiene todos los estados de tarea y los asigna a la variable estadoTareas.
                estadoTareas = await bdContexto.EstadoTareaEN.ToListAsync();
            }
            // Retorna la lista de estados de tarea.
            return estadoTareas;
        }

    }

}

﻿using GestordeTaras.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class TareaBL
    {
        public async Task<int> CreateAsync(Tarea tarea)
        {
            return await TareaDAL.CreateAsync(tarea);
        }
        public async Task<int> UpdateAsync(Tarea tarea)
        {
            return await TareaDAL.UpdateAsync(tarea);
        }
        public async Task<int> DeliteAsync(Tarea tarea)
        {
            return await TareaDAL.UpdateAsync(tarea);
        }
        public async Task<Tarea> GetById(Tarea tarea)
        {
            return await TareaDAL.GetByIdAsync(tarea);
        }
        public async Task<List<Tarea>> GetAllAsync()
        {
            return await TareaDAL.GetAllAsync();
        }
    }
}

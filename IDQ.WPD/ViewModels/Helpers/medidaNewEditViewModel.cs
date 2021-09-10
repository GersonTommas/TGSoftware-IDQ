﻿using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class medidaNewEditViewModel : Base.ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public medidaNewEditViewModel() { }

        public void setInitialize(medidaModel sentMedida)
        {
            if (sentMedida != null)
            {
                _editMedida = sentMedida;
                newMedida = new medidaModel()
                {
                    Activo = sentMedida.Activo,
                    Medida = sentMedida.Medida,
                    Tipo = sentMedida.Tipo
                };
                isEdit = true;
            }
        }


        bool _isEdit;
        public bool isEdit { get => _isEdit; set { if (SetProperty(ref _isEdit, value)) { OnPropertyChanged(); } } }

        public string groupBoxTitle => isEdit ? "ID: " + _editMedida.Id : "Nueva Medida";

        medidaModel _editMedida;

        medidaModel _newMedida = new medidaModel() { Activo = true };
        public medidaModel newMedida { get => _newMedida; set { if (SetProperty(ref _newMedida, value)) { OnPropertyChanged(); } } }



        void helperGuardar(object sentParameter)
        {
            medidaModel compareMedida = null;
            if (!string.IsNullOrWhiteSpace(newMedida.Medida)) { newMedida.Medida = newMedida.Medida.Trim(); }

            try { compareMedida = context.globalDb.medidas.Single(x => x.Medida.ToLower() == newMedida.Medida.ToLower() && x.Tipo == newMedida.Tipo); } catch { }

            if (isEdit)
            {
                if (compareMedida == null || compareMedida.Id == _editMedida.Id)
                {
                    _editMedida.Activo = newMedida.Activo; _editMedida.Medida = newMedida.Medida;
                    _ = context.globalDb.SaveChanges();
                    Shared.GlobalVars.messageError.Guardado();

                    //thisWindow.DialogResult = true;
                }
                else { Shared.GlobalVars.messageError.Existencia(); }
            }
            else if (compareMedida == null)
            {
                _ = context.globalDb.medidas.Add(newMedida);
                _ = context.globalDb.SaveChanges();
                Shared.GlobalVars.messageError.Guardado();

                //thisWindow.DialogResult = true;
                if (Navigator != null) { Navigator.CurrentViewModel = null; }
            }
            else { Shared.GlobalVars.messageError.Existencia(); }
        }

        bool checkGuardar => !string.IsNullOrWhiteSpace(newMedida.Medida) && newMedida.Medida.Length > 0 && newMedida.Tipo > 0;


        public Command guardarCommand => new Command(
            (object parameter) => helperGuardar(parameter),
            (object parameter) => checkGuardar);
    }
}

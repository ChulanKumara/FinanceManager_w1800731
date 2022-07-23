using FinanceManager.Models;
using System;
using System.Collections.Generic;

namespace FinanceManager.Common
{
    public static class CommonValues
    {
        public static List<ComboBoxDTO> ComboboxDataBind(Type enumType)
        {
            List<ComboBoxDTO> comboBoxDTOs = new List<ComboBoxDTO>();
            ComboBoxDTO comboBoxDTO = new ComboBoxDTO();
            comboBoxDTO.ValueField = "0";
            comboBoxDTO.TextField = "- Select -";
            comboBoxDTOs.Add(comboBoxDTO);
            var listOfValues = Enum.GetValues(enumType);
            int i = 1;
            foreach (var value in listOfValues)
            {
                ComboBoxDTO oDroListnew = new ComboBoxDTO();
                oDroListnew.ValueField = i.ToString();
                oDroListnew.TextField = value.ToString();
                comboBoxDTOs.Add(oDroListnew);
                i++;
            }
            return comboBoxDTOs;
        }
    }
}
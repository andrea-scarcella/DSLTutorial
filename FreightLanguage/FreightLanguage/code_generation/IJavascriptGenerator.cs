﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreightLanguage.code_generation
{
   public interface IJavascriptGenerator
    {
        void GenerateScript(StringBuilder builder);
    }
}
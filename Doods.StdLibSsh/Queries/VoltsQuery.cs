﻿using Doods.StdLibSsh.Base.Queries;
using Doods.StdLibSsh.Interfaces;
using System;
using System.Globalization;

namespace Doods.StdLibSsh.Queries
{
    public class VoltsQuery : GenericQuery<double>
    {
        private readonly string VOLTS_CMD = " measure_volts core";
        private readonly string _vcgencmdPath;
        public VoltsQuery(IClientSsh client, string vcgencmdPath) : base(client)
        {

            _vcgencmdPath = vcgencmdPath;
            CmdString = _vcgencmdPath + VOLTS_CMD;
        }

        protected override double PaseResult(string result)
        {
            return FormatVolts(result);
        }
        private double FormatVolts(string output)
        {
            var splitted = output.Trim().Split('=');
            if (splitted.Length >= 2)
            {
                var voltsWithUnit = splitted[1];
                var volts = voltsWithUnit.Substring(0,
                    voltsWithUnit.Length - 1);


                if (double.TryParse(volts, NumberStyles.Float, CultureInfo.InvariantCulture, out double res2))
                {
                    return res2;
                }


            }

            Logger.Instance.Error("Could not parse cpu voltage.");
            Logger.Instance.Error($"Output of 'vcgencmd measure_volts core': {Environment.NewLine}{output}");
            return 0D;

        }
    }
}

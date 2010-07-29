﻿using System;
using VVVV.PluginInterfaces.V1;
using VVVV.Utils.VColor;

namespace VVVV.PluginInterfaces.V2
{
	public class ColorOutputPin : OutputPin<RGBAColor>
	{
		protected IColorOut FColorOut;
		
		public ColorOutputPin(IPluginHost host, OutputAttribute attribute)
		{
			host.CreateColorOutput(attribute.Name, attribute.SliceMode, attribute.Visibility, out FColorOut);
			FColorOut.SetSubType(new RGBAColor(attribute.DefaultColor), attribute.HasAlpha);
		}
		
		public override IPluginOut PluginOut
		{
			get 
			{
				return FColorOut;
			}
		}
		
		public override RGBAColor this[int index] 
		{
			get 
			{
				throw new NotImplementedException();
			}
			set 
			{
				FColorOut.SetColor(index, value);
			}
		}
	}
}
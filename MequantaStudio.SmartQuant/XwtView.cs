using System;
using MonoDevelop.Ide.Gui;
using Xwt;

namespace MequantaStudio.SmartQuant
{
	public interface IXwtView : IAttachableViewContent
	{
	}

	public class XwtView : AbstractXwtViewContent, IXwtView
	{
		Label widget = new Label ("Xwt Widget");

		public override Widget Widget { get { return widget; } }

		public override void Load (string fileName)
		{
			throw new InvalidOperationException();
		}

		public void Selected ()
		{
		}

		public void Deselected ()
		{
		}

		public new void BeforeSave ()
		{
		}

		public void BaseContentChanged ()
		{
		}
	}
}


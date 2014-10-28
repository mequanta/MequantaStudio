﻿using System;
using MonoDevelop.Ide.Gui;
using Gtk;
using MonoDevelop.Core;

namespace MequantaStudio.SmartQuant
{
    public class OrderManagerViewContent : NoProjectViewContent
    {
        private OrderManagerWidget widget;

        public OrderManagerViewContent()
        {
            ContentName = GettextCatalog.GetString("Order Manager");
            widget = new OrderManagerWidget();
            Control.ShowAll();
        }

        public override Widget Control
        {
            get
            {
                return widget;
            }
        }

        private void Update()
        {
        }
    }
}


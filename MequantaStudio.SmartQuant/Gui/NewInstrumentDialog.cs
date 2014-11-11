using System;
using SmartQuant;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    public partial class NewInstrumentDialog : Gtk.Dialog
    {
        private Instrument newInstrument;

        public string Symbol
        {
            get
            {
                return this.txtSymbol.Text.Trim();
            }
        }

        public InstrumentType InstrumentType
        {
            get
            {
                var s = cbxType.ActiveText;
                return (InstrumentType)Enum.Parse(typeof(InstrumentType), s);
            }
            set
            {
                //  this.cbxInstrumentTypes.SelectedItem = (object) value;
            }
        }

        public string Exchange
        {
            get
            {
                return this.txtExchange.Text.Trim();
            }
        }

        public byte CurrencyId
        {
            get
            {
                byte result;
                if (!byte.TryParse(this.txtCurrency.Text.Trim(), out result))
                    return (byte)0;
                else
                    return result;
            }
        }

        public DateTime Maturity
        {
            get
            {
                var t = DateTime.Now;
                DateTime.TryParse(dtpMaturity.ActiveText, out t);
                return t;
            }
        }

        public PutCall PutCall
        {
            get
            {
                var s = cbxPutCall.ActiveText;
                return (PutCall)(Enum.Parse(typeof(PutCall), s));
            }
        }

        public double Strike
        {
            get
            {
                return this.sbnStrike.Value;
            }
        }

        public Instrument NewInstrument
        { 
            get
            {
                return this.newInstrument;
            }
        }

        public NewInstrumentDialog()
        {
            Build();
            Title = "Add new instrument";
            Modal = true;
        }

//        protected override void OnResponse(ResponseType responseId)
//        {
//            if (responseId == ResponseType.Ok)
//            {
//                NewInstrument = new Instrument(InstrumentType, Symbol, "", CurrencyId);
//                NewInstrument.Maturity = Maturity;
//                NewInstrument.PutCall = PutCall;
//            }
//            base.OnResponse(responseId);
//        }
    }
}


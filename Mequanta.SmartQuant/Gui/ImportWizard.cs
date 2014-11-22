using System;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    public class ImportWizard : Gtk.Assistant
    {
        private ImportWizardStep1Widget step1;
        private ImportWizardStep2Widget step2;
        private ImportWizardStep3Widget step3;

        public ImportWizard()
        {
            SetSizeRequest(450, 320);
            step1 = new ImportWizardStep1Widget();
            step2 = new ImportWizardStep2Widget();
            step3 = new ImportWizardStep3Widget();

            AppendPage(step1);
            SetPageTitle(step1, "step 1 of 3 - Select File(s) to Import");
            SetPageType(step1, AssistantPageType.Progress);
            SetPageComplete(step1, true);

            AppendPage(step2);
            SetPageTitle(step2, "step 2 of 3 - Set Import Template");
            SetPageType(step2, AssistantPageType.Progress);
            SetPageComplete(step2, true);

            AppendPage(step3);
            SetPageTitle(step3, "step 3 of 3 - Process File(s)");
            SetPageType(step3, AssistantPageType.Confirm);
            SetPageComplete(step3, true);

            Modal = true;
            Close += (sender, e) => Destroy();
            Cancel += (sender, e) => Destroy();
        }
    }
}


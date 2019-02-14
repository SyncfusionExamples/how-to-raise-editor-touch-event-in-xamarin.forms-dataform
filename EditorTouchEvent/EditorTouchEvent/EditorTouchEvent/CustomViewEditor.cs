using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.DataForm.Editors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EditorTouchEvent
{
    public class CustomViewEditor : DataFormEditor<CustomView>
    {
        public CustomViewEditor(SfDataForm dataForm) : base(dataForm)
        {

        }
        protected override CustomView OnCreateEditorView(DataFormItem dataFormItem)
        {
            return new CustomView();
        }
        protected override void OnInitializeView(DataFormItem dataFormItem, CustomView view)
        {
            base.OnInitializeView(dataFormItem, view);
        }

    }

    public class CustomView : View
    {
        public CustomView()
        {

        }
    }
}

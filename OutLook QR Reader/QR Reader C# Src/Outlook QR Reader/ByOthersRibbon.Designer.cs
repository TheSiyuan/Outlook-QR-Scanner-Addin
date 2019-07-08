namespace Outlook_QR_Reader
{
    partial class ByOthersRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ByOthersRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ByOthersRibbon));
            this.TabByOthers = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.QRReader_BTN = this.Factory.CreateRibbonButton();
            this.TabByOthers.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabByOthers
            // 
            this.TabByOthers.Groups.Add(this.group1);
            this.TabByOthers.Label = "ByOthers";
            this.TabByOthers.Name = "TabByOthers";
            // 
            // group1
            // 
            this.group1.Items.Add(this.QRReader_BTN);
            this.group1.Label = "QR Code";
            this.group1.Name = "group1";
            // 
            // QRReader_BTN
            // 
            this.QRReader_BTN.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.QRReader_BTN.Image = global::Outlook_QR_Reader.Properties.Resources.qr_scan;
            this.QRReader_BTN.Label = "QR Reader";
            this.QRReader_BTN.Name = "QRReader_BTN";
            this.QRReader_BTN.ScreenTip = "Click then click the QR code";
            this.QRReader_BTN.ShowImage = true;
            this.QRReader_BTN.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.QRReader_BTN_Click);
            // 
            // ByOthersRibbon
            // 
            this.Name = "ByOthersRibbon";
            this.RibbonType = resources.GetString("$this.RibbonType");
            this.Tabs.Add(this.TabByOthers);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.TabByOthers.ResumeLayout(false);
            this.TabByOthers.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabByOthers;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton QRReader_BTN;
    }

    partial class ThisRibbonCollection
    {
        internal ByOthersRibbon Ribbon1
        {
            get { return this.GetRibbon<ByOthersRibbon>(); }
        }
    }
}

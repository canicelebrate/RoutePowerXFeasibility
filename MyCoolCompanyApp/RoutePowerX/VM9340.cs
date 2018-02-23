using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PCLStorage;
using System.Threading.Tasks;

namespace MyCoolCompanyApp.RoutePowerX
{
    public class VM9340: BindableBase
    {
        #region :: Fields ::
        INavigationService _navigationService;
        #endregion


        #region :: Commands ::
        DelegateCommand _exitCmd;
        public DelegateCommand ExitCmd
        {
            get
            {
                return _exitCmd;
            }
            private set
            {
                _exitCmd = value;
            }
        }

        DelegateCommand<SignaturePad.Forms.SignaturePadView> _saveStreamCmd;
        public DelegateCommand<SignaturePad.Forms.SignaturePadView> SaveStreamCmd
        {
            get
            {
                return _saveStreamCmd;
            }
            set
            {
                _saveStreamCmd = value;
            }
        }

        #endregion


        public VM9340(INavigationService navigationService)
        {
            _navigationService = navigationService;

            this._exitCmd = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });

            this._saveStreamCmd = new DelegateCommand<SignaturePad.Forms.SignaturePadView>(async (sigView) =>
            {
                await Task.Run(async () =>
                {
                    
                    var rootFolder = FileSystem.Current.LocalStorage;
                    var checkResult = await rootFolder.CheckExistsAsync("data");
                    IFolder folder = null;
                    if (checkResult != ExistenceCheckResult.FolderExists)
                    {
                        folder = await rootFolder.CreateFolderAsync("data", CreationCollisionOption.OpenIfExists);
                    }
                    else
                    {
                        folder = await rootFolder.GetFolderAsync("data");
                    }
                    var sigFile = await folder.CreateFileAsync("mysig.png", CreationCollisionOption.ReplaceExisting);

                    var stream = await sigView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                    using (var oStream = await sigFile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
                    {
                        await stream.CopyToAsync(oStream);
                        await oStream.FlushAsync();
                    }
                });

 

            });


        }
    }
}

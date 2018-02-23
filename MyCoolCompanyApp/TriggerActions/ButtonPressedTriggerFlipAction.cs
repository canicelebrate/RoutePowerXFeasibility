using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace MyCoolCompanyApp.TriggerActions
{
    public class ButtonPressedTriggerFlipAction : TriggerAction<ImageButton>
    {
        #region :: Constants ::
        static readonly Rectangle kLeftHalfBounds = new Rectangle(0, 0, 0.5, 1);
        static readonly AbsoluteLayoutFlags kLeftFlags = AbsoluteLayoutFlags.SizeProportional;

        static readonly Rectangle kRightHalfBounds = new Rectangle(1, 0, 0.5, 1);
        static readonly AbsoluteLayoutFlags kRightFlags = AbsoluteLayoutFlags.SizeProportional | AbsoluteLayoutFlags.XProportional;
        #endregion

        #region :: Fields ::
        VisualElement _left;
        VisualElement _right;
        #endregion


        #region :: Properties ::
        public VisualElement Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        public VisualElement Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }
        #endregion

        protected override void Invoke(ImageButton sender)
        {
            Rectangle leftRect = (Rectangle)Left.GetValue(AbsoluteLayout.LayoutBoundsProperty);
            if (leftRect == kLeftHalfBounds)
            {
                //没有切换前的状态，进行左右切换
                AbsoluteLayout.SetLayoutBounds(Left, kRightHalfBounds);
                AbsoluteLayout.SetLayoutFlags(Left, kRightFlags);

                AbsoluteLayout.SetLayoutBounds(Right, kLeftHalfBounds);
                AbsoluteLayout.SetLayoutFlags(Right, kLeftFlags);

            }
            else
            {
                //已经切换过了，需要切换回来
                AbsoluteLayout.SetLayoutBounds(Left, kLeftHalfBounds);
                AbsoluteLayout.SetLayoutFlags(Left, kLeftFlags);

                AbsoluteLayout.SetLayoutBounds(Right, kRightHalfBounds);
                AbsoluteLayout.SetLayoutFlags(Right, kRightFlags);
            }
        }
    }
}

﻿using AppKit;

using Microsoft.Maui.Platform;

using UIKit;

namespace DemyAI.Platforms.MacCatalyst {
    public static class CursorExtensions {

        public static void SetCustomCursor(this VisualElement visualElement, CursorIcon cursor, IMauiContext mauiContext) {

            ArgumentNullException.ThrowIfNull(mauiContext);
            var view = visualElement.ToPlatform(mauiContext);
            if (view.GestureRecognizers is not null) {

                foreach (var rognizers in view.GestureRecognizers.OfType<PointerUIHoverGestureRecognizer>()) {

                    view.RemoveGestureRecognizer(rognizers);
                }
            }

            view.AddGestureRecognizer(new UIHoverGestureRecognizer(r => {

                switch (r.State) {

                    case UIGestureRecognizerState.Began:
                        GetNSCursor(cursor).Set();
                        break;
                    case UIGestureRecognizerState.Ended:
                        NSCursor.ArrowCursor.Set();
                        break;
                    default:
                        break;
                }
            }));
        }

        static NSCursor GetNSCursor(CursorIcon cursor) {
            return cursor switch {

                CursorIcon.Hand => NSCursor.OpenHandCursor,
                CursorIcon.IBeam => NSCursor.IBeamCursor,
                CursorIcon.Cross => NSCursor.CrosshairCursor,
                CursorIcon.Arrow => NSCursor.ArrowCursor,
                CursorIcon.SizeAll => NSCursor.ResizeUpCursor,
                CursorIcon.Wait => NSCursor.OperationNotAllowedCursor,
                _ => NSCursor.ArrowCursor
            };
        }

        class PointerUIHoverGestureRecognizer : UIHoverGestureRecognizer {

            public PointerUIHoverGestureRecognizer(Action<UIHoverGestureRecognizer> action) : base(action) { }
        }
    }
}

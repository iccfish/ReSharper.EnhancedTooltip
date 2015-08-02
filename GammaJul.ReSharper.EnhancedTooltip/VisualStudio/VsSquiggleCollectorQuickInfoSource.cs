using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.TextControl.DocumentMarkup;
using JetBrains.Util;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;

namespace GammaJul.ReSharper.EnhancedTooltip.VisualStudio {

	/// <summary>
	/// This class only stores squiggles added by Roslyn inside the session, so they can be identified easily later in <see cref="MainQuickInfoSource"/>.
	/// </summary>
	public class VsSquiggleCollectorQuickInfoSource : QuickInfoSourceBase {

		protected override void AugmentQuickInfoSessionCore(
			IQuickInfoSession session,
			IList<object> quickInfoContent,
			IDocumentMarkup documentMarkup,
			TooltipFormattingProvider tooltipFontProvider,
			out ITrackingSpan applicableToSpan) {

			applicableToSpan = null;

			session.StoreVsSquiggleContents(quickInfoContent.ToArray());
		}
		
		public VsSquiggleCollectorQuickInfoSource([NotNull] IVsEditorAdaptersFactoryService editorAdaptersFactoryService, [NotNull] ITextBuffer textBuffer)
			: base(editorAdaptersFactoryService, textBuffer) {
		}

	}

}
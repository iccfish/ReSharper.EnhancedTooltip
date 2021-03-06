using GammaJul.ReSharper.EnhancedTooltip.DocumentMarkup;
using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Psi.CodeAnnotations;

namespace GammaJul.ReSharper.EnhancedTooltip.Presentation.Highlightings.CSharp {

	[SolutionComponent]
	internal sealed class CannotApplyBinaryOperatorErrorEnhancer : CSharpHighlightingEnhancer<CannotApplyBinaryOperatorError> {

		protected override void AppendTooltip(CannotApplyBinaryOperatorError highlighting, CSharpColorizer colorizer) {
			colorizer.AppendPlainText("Cannot apply operator '");
			colorizer.AppendOperator(highlighting.Sign.GetText());
			colorizer.AppendPlainText("' to operands of type '");
			colorizer.AppendExpressionType(highlighting.LeftType, false, PresenterOptions.FullWithoutParameterNames);
			colorizer.AppendPlainText("' and '");
			colorizer.AppendExpressionType(highlighting.RightType, false, PresenterOptions.FullWithoutParameterNames);
			colorizer.AppendPlainText("'");
		}
		
		public CannotApplyBinaryOperatorErrorEnhancer(
			[NotNull] TextStyleHighlighterManager textStyleHighlighterManager,
			[NotNull] CodeAnnotationsCache codeAnnotationsCache,
			[NotNull] HighlighterIdProviderFactory highlighterIdProviderFactory)
			: base(textStyleHighlighterManager, codeAnnotationsCache, highlighterIdProviderFactory) {
		}

	}

}
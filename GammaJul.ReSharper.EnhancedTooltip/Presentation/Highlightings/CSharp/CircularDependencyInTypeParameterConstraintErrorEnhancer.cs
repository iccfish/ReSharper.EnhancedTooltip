using GammaJul.ReSharper.EnhancedTooltip.DocumentMarkup;
using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Psi.CodeAnnotations;
using JetBrains.ReSharper.Psi.Resolve;

namespace GammaJul.ReSharper.EnhancedTooltip.Presentation.Highlightings.CSharp {

	[SolutionComponent]
	internal sealed class CircularDependencyInTypeParameterConstraintErrorEnhancer : CSharpHighlightingEnhancer<CircularDependencyInTypeParameterConstraintError> {

		protected override void AppendTooltip(CircularDependencyInTypeParameterConstraintError highlighting, CSharpColorizer colorizer) {
			colorizer.AppendPlainText("Circular constraint dependency involving '");
			colorizer.AppendDeclaredElement(highlighting.Origin, EmptySubstitution.INSTANCE, PresenterOptions.NameOnly);
			colorizer.AppendPlainText("' and '");
			colorizer.AppendDeclaredElement(highlighting.Parameter, EmptySubstitution.INSTANCE, PresenterOptions.NameOnly);
			colorizer.AppendPlainText("'");
		}
		
		public CircularDependencyInTypeParameterConstraintErrorEnhancer(
			[NotNull] TextStyleHighlighterManager textStyleHighlighterManager,
			[NotNull] CodeAnnotationsCache codeAnnotationsCache,
			[NotNull] HighlighterIdProviderFactory highlighterIdProviderFactory)
			: base(textStyleHighlighterManager, codeAnnotationsCache, highlighterIdProviderFactory) {
		}

	}

}
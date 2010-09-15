using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PGK.Extensions {
	/// <summary>
	/// Extension methods for IComponent data type.
	/// </summary>
	public static class ComponentExtensions {
		/// <summary>
		/// Returns <c>true</c> if target component is in design mode.
		/// Othervise returns <c>false</c>.
		/// </summary>
		/// <param name="target">Target component. Can not be null.</param>
		public static bool IsInDesignMode(this IComponent target) {
			bool ret = false;
			var site = target.Site;
			if (false == object.ReferenceEquals(site, null)) {
				ret = site.DesignMode;
			}

			return ret;
		}

		/// <summary>
		/// Returns <c>true</c> if target component is NOT in design mode.
		/// Othervise returns <c>false</c>.
		/// </summary>
		/// <param name="target">Target component.</param>
		public static bool IsInRuntimeMode(this IComponent target) {
			bool ret = true;
			var site = target.Site;
			if (false == object.ReferenceEquals(site, null)) {
				ret = !site.DesignMode;
			}

			return ret;
		}
	}
}

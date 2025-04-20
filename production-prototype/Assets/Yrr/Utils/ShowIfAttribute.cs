/* Title : Attribute for show a field if other field is true or false.
 * Author : Anth
*/
using UnityEngine;
using UnityEditor;


namespace Yrr.Utils
{
#if UNITY_EDITOR
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class ShowIfAttribute : PropertyAttribute
    {
        public string ConditionalSourceField;
        public int expectedNumber;
        public bool expectedValue;
        public bool HideInInspector;

        /// <summary>
        /// Create the attribute for show a field x if field y is true or false.
        /// </summary>
        /// <param name="ConditionalSourceField">name of field y type boolean </param>
        /// <param name="expectedValue"> what value should have the field y for show the field x</param>
        /// <param name="HideInInspector"> if should hide in the inspector or only disable</param>
        public ShowIfAttribute(string ConditionalSourceField, bool expectedValue, bool HideInInspector = true)
        {
            this.ConditionalSourceField = ConditionalSourceField;
            this.expectedValue = expectedValue;
            this.HideInInspector = HideInInspector;
        }

        public ShowIfAttribute(string ConditionalSourceField, int expectedNumber, bool HideInInspector = true)
        {
            this.ConditionalSourceField = ConditionalSourceField;
            this.expectedNumber = expectedNumber;
            this.HideInInspector = HideInInspector;
        }
    }



    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowIfAttribute condHAtt = (ShowIfAttribute)attribute;
            bool enabled = GetConditionalSourceField(property, condHAtt);
            GUI.enabled = enabled;

            // if is enable draw the label
            if (enabled)
                EditorGUI.PropertyField(position, property, label, true);
            // if is not enabled but we want not hide it, then draw it disabled
            else if (!condHAtt.HideInInspector)
                EditorGUI.PropertyField(position, property, label, false);
            // else hide it ,dont draw it
            else return;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {

            ShowIfAttribute condHAtt = (ShowIfAttribute)attribute;
            bool enabled = GetConditionalSourceField(property, condHAtt);

            // if is enable draw the label
            if (enabled)
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }
            // if is not enabled but we want not hide it, then draw it disabled
            else
            {
                if (!condHAtt.HideInInspector)
                    return EditorGUI.GetPropertyHeight(property, label, false);
                // else hide it
                else
                    return -EditorGUIUtility.standardVerticalSpacing; // Oculta el campo visualmente.
            }
            return 0f;
        }

        /// <summary>
        /// Get if the conditional what expected is true.
        /// </summary>
        /// <param name="property"> is used for get the value of the property and check if return enable true or false </param>
        /// <param name="condHAtt"> is the attribute what contains the values what we need </param>
        /// <returns> only if the field y is same to the value expected return true</returns>
        private bool GetConditionalSourceField(SerializedProperty property, ShowIfAttribute condHAtt)
        {
            bool enabled = false;
            string propertyPath = property.propertyPath;
            string conditionPath = propertyPath.Replace(property.name, condHAtt.ConditionalSourceField);
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

            if (sourcePropertyValue != null)
            {
                if (condHAtt.expectedNumber != -1)
                {
                    return condHAtt.expectedNumber == sourcePropertyValue.intValue;
                }

                enabled = sourcePropertyValue.boolValue;
                if (enabled == condHAtt.expectedValue)
                    enabled = true;
                else enabled = false;
            }
            else
            {
                string warning = "ConditionalHideAttribute: No se encuentra el campo booleano [" + condHAtt.ConditionalSourceField + "] en " + property.propertyPath;
                warning += " Asegúrate de especificar correctamente el nombre del campo condicional.";
                Debug.LogWarning(warning);
            }

            return enabled;

        }
    }

#else
public sealed class ShowIfAttribute : PropertyAttribute
{
}
#endif
}

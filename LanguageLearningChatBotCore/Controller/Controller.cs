using System;
using System.Collections.Generic;

namespace LanguageLearningChatBotCore
{
    public static class ControllerSingleton
    {
        private static int nextId = 0;
        static Dictionary<int, Controller> controllers = new Dictionary<int, Controller>();
        public static int GetInstanceID(Language primary, Language secondary)
        {
            Controller newController = new Controller(primary, secondary);
            int usedID = nextId;
            nextId++;
            controllers.Add(usedID, newController);
            return usedID;
        }

        public static ResponseAnalysis Respond(int controllerID, string data)
        {
            Controller controller = null;
            controllers.TryGetValue(controllerID, out controller);
            if (controller != null)
            {
                return controller.Respond(data);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    internal class Controller
    {
        private Language m_primary;
        private Language m_secondary;

        private ControllerAPIImpl m_controllerAPIImpl = new ControllerAPIImpl();

        public Controller(Language primary, Language secondary)
        {
            m_primary = primary;
            m_secondary = secondary;
        }

        public ResponseAnalysis Respond(string data)
        {
            return m_controllerAPIImpl.Respond(m_primary, m_secondary, data);
        }
    }
}
using System;
using System.Collections.Generic;

namespace LanguageLearningChatBotCore
{
    public static class ControllerSingleton
    {
        private static int nextId = 0;
        static List<Controller> controllers = new List<Controller>();
        public static Controller GetInstance(Language primary, Language secondary)
        {
            Controller newController = new Controller(nextId, primary, secondary);
            nextId++;
            controllers.Add(newController);
            return newController;
        }
    }

    public class Controller
    {
        private int m_id;
        private Language m_primary;
        private Language m_secondary;

        private ControllerAPIImpl m_controllerAPIImpl = new ControllerAPIImpl();

        public Controller(int Id, Language primary, Language secondary)
        {
            m_id = Id; 
            m_primary = primary;
            m_secondary = secondary;
        }

        public TranslationData Translate(string data)
        {
            return m_controllerAPIImpl.Translate(m_primary, m_secondary, data);
        }

        public ResponseAnalysis Respond(string data)
        {
            return m_controllerAPIImpl.Respond(m_primary, m_secondary, data);
        }
    }
}
public class AllSentences
{
    public string[] FlameSentences = new[] {
        "¿Has dejado ya de usar pañales?",
        "¡No hay palabras para describir lo asqueroso que eres!",
        "¡He hablado con simios más educados que tu!",
        "¡Llevarás mi espada como si fueras un pincho moruno!",
        "¡Luchas como un ganadero!",
        "¡No pienso aguantar tu insolencia aquí sentado!",
        "¡Mi pañuelo limpiará tu sangre!",
        "¡Ha llegado tu HORA, palurdo de ocho patas!",
        "¡Una vez tuve un perro más listo que tu!",
        "¡Nadie me ha sacado sangre jamás, y nadie lo hará!",
        "¡Me das ganas de vomitar!",
        "¡Tienes los modales de un mendigo!",
        "¡He oído que eres un soplón despreciable!",
        "¡La gente cae a mis pies al verme llegar!",
        "¡Demasiado bobo para mi nivel de inteligencia!",
        "Obtuve esta cicatriz en una batalla a muerte!"
    };

    public string[] Comebacks = new[] {
        "¿Por qué? ¿Acaso querías pedir uno prestado?",
        "Sí que las hay, sólo que nunca las has aprendido.",
        "Me alegra que asistieras a tu reunión familiar diaria.",
        "Primero deberías dejar de usarla como un plumero.",
        "Qué apropiado, tú peleas como una vaca.",
        "Ya te están fastidiando otra vez las almorranas, ¿Eh?",
        "Ah, ¿Ya has obtenido ese trabajo de barrendero?",
        "Y yo tengo un SALUDO para ti, ¿Te enteras?",
        "Te habrá enseñado todo lo que sabes.",
        "¿TAN rápido corres?",
        "Me haces pensar que alguien ya lo ha hecho.",
        "Quería asegurarme de que estuvieras a gusto conmigo.",
        "Qué pena me da que nadie haya oído hablar de ti",
        "¿Incluso antes de que huelan tu aliento?",
        "Estaría acabado si la usases alguna vez.",
        "Espero que ya hayas aprendido a no tocarte la nariz."
    };

    private bool correctComeback = false;

    // assign every comeback to its flame
    public bool CorrectAnswer(int flameIndex, int comebackIndex)
    {
        correctComeback = false;

        switch (flameIndex)
        {
            case 0:
                if(comebackIndex == 0)
                    correctComeback = true;
                break;
            case 1:
                if (comebackIndex == 1)
                    correctComeback = true;
                break;
            case 2:
                if (comebackIndex == 2)
                    correctComeback = true;
                break;
            case 3:
                if (comebackIndex == 3)
                    correctComeback = true;
                break;
            case 4:
                if (comebackIndex == 4)
                    correctComeback = true;
                break;
            case 5:
                if (comebackIndex == 5)
                    correctComeback = true;
                break;
            case 6:
                if (comebackIndex == 6)
                    correctComeback = true;
                break;
            case 7:
                if (comebackIndex == 7)
                    correctComeback = true;
                break;
            case 8:
                if (comebackIndex == 8)
                    correctComeback = true;
                break;
            case 9:
                if (comebackIndex == 9)
                    correctComeback = true;
                break;
            case 10:
                if (comebackIndex == 10)
                    correctComeback = true;
                break;
            case 11:
                if (comebackIndex == 11)
                    correctComeback = true;
                break;
            case 12:
                if (comebackIndex == 12)
                    correctComeback = true;
                break;
            case 13:
                if (comebackIndex == 13)
                    correctComeback = true;
                break;
            case 14:
                if (comebackIndex == 14)
                    correctComeback = true;
                break;
            case 15:
                if (comebackIndex == 15)
                    correctComeback = true;
                break;
            default:
                break;
        }

        return correctComeback;
    }
}

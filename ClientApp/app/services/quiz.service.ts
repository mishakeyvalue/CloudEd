import { Injectable } from '@angular/core';

import { Quiz } from './../models/quiz'
import { Question } from './../models/question'
import { Answer } from './../models/answer'

@Injectable()
export class QuizService {
    private stubbedQuizez: Quiz[];
    public greeting: string = "Hello from my service!";

    constructor() {
        this.stubbedQuizez =
            [
                {
                    id: "dotnet-quiz",
                    title: "ASP.NET basics",
                    description: "It wiil help you test your knowledge of the robust and powerfull web development tool!",
                    questions: this.stubbedQuestions
                },
                {
                    id: "dotnet-quiz",
                    title: "Another ASP.NET basics",
                    description: "It wiil help you test your knowledge of the robust and powerfull web development tool!",
                    questions: this.stubbedQuestions
                },

            ];
    }

    public getAll(): Quiz[] {
        return this.stubbedQuizez;
    }

    get stubbedQuestions(): Question[] {
        let stub: Question[] =
            [
                {
                    id: "stubbed-question",
                    title: "Some title",
                    answers:
                    [
                        { id: "answer", body: "42" },
                        { id: "answer", body: "12" },
                        { id: "answer", body: "55" }
                    ],
                    selectedAnswer: null
                },

                {
                    id: "stubbed-question",
                    title: "What is your favourite meal?",
                    answers:
                    [
                        { id: "answer", body: "42" },
                        { id: "answer", body: "banana" },
                        { id: "answer", body: "55" }
                    ],
                    selectedAnswer: null
                },

                {
                    id: "stubbed-question",
                    title: "Banana?",
                    answers:
                    [
                        { id: "answer", body: "Yes" },
                        { id: "answer", body: "Of course!" },
                        { id: "answer", body: "42" },
                        { id: "answer", body: "42? 42!" }
                    ],
                    selectedAnswer: null
                }
            ];
        return stub;
    }

}


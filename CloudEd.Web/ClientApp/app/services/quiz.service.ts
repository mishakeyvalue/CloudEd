import { Injectable } from '@angular/core';

import { QuizViewModel } from './../models/quizViewModel';
import { QuestionViewModel } from './../models/questionViewModel'
import { AnswerViewModel } from './../models/answerViewModel'

@Injectable()
export class QuizService {
    private stubbedQuizez: QuizViewModel[];
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
                    id: "potato",
                    title: "Another ASP.NET basics",
                    description: "It wiil help you test your knowledge of the robust and powerfull web development tool!",
                    questions: this.stubbedQuestions
                },

            ];
    }

    public getAll(): QuizViewModel[] {
        return this.stubbedQuizez;
    }

    get stubbedQuestions(): QuestionViewModel[] {
        let stub: QuestionViewModel[] =
            [
                {
                    id: this.randomId,
                    title: "Some title",
                    answers:
                    [
                        { id: this.randomId, body: "42", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "12", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "55", questionId: this.randomId, isSelected: false }
                    ],
                    selectedAnswer: null
                },

                {
                    id: this.randomId,
                    title: "What is your favourite meal?",
                    answers:
                    [
                        { id: this.randomId, body: "42", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "banana", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "55", questionId: this.randomId, isSelected: false }
                    ],
                    selectedAnswer: null
                },

                {
                    id: this.randomId,
                    title: "Banana?",
                    answers:
                    [
                        { id: this.randomId, body: "Yes", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "Of course!", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "42", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "42? 42!", questionId: this.randomId, isSelected: false }
                    ],
                    selectedAnswer: null
                }
            ];
        return stub;
    }

    private static counter: number = 0;

    private get randomId(): string {
        return `random-id-${QuizService.counter++}`;
    }

}


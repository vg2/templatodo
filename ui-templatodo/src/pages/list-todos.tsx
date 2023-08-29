import { Accordion, AccordionContent, AccordionItem, AccordionTrigger } from "@/components/ui/accordion";
import { Badge } from "@/components/ui/badge";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Checkbox } from "@/components/ui/checkbox";
import { Template } from "@/data/template";
import { cn } from "@/lib/utils";

const ListTodos = () => {
    const templates: Template[] = [
        {
            name: 'Baby activites',
            todos: [{
                activity: 'Flash cards',
                description: 'Show baby flash cards',
                durationInMinutes: 5,
                timeOfDay: 'P1: 18:00 - 19:00',
                note: 'Card sets: 1,2'
            }]
        }
    ];

    return (
        <>
            <h2>To do today</h2>
            <Accordion type="single" collapsible>
                {templates.map((template => (
                    <AccordionItem value={template.name}>
                        <AccordionTrigger>{template.name}</AccordionTrigger>
                        <AccordionContent>
                            {template.todos.map(todo => (
                                <Card className="text-left">
                                    <CardHeader>
                                        <CardTitle><Checkbox /> {todo.activity}</CardTitle>
                                        <CardDescription>{todo.description}</CardDescription>
                                    </CardHeader>
                                    <CardContent>
                                        <div>
                                            {todo.durationInMinutes} minutes
                                        </div>
                                        <div>
                                            {todo.note}
                                        </div>
                                    </CardContent>
                                    <CardFooter>
                                        <Badge>{todo.timeOfDay}</Badge>
                                    </CardFooter>
                                </Card>
                            ))}
                        </AccordionContent>
                    </AccordionItem>
                )))}
            </Accordion>
        </>
    );
}

export default ListTodos;
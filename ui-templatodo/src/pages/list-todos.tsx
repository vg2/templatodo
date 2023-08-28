import { Accordion, AccordionContent, AccordionItem, AccordionTrigger } from "@/components/ui/accordion";
import { Template } from "@/data/template";

const ListTodos = () => {
    const templates: Template[] = [
        {
            name: 'Baby activites',
            todos: [{
                activity: 'Flash cards',
                description: 'Show baby flash cards',
                durationInMinutes: 5,
                timeOfDay: '18:30'
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
                            <ul>
                                {template.todos.map(todo => (
                                    <li>{todo.activity}</li>
                                ))}
                            </ul>
                        </AccordionContent>
                    </AccordionItem>
                )))}
            </Accordion>
        </>
    );
}

export default ListTodos;
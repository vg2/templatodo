import { useRouteError } from "react-router-dom";

const ErrorPage = () => {
    const error: {statusText: string, message: string } = useRouteError() as any;
    console.error(error);
    return (
        <>
            <h1>Something went wrong!</h1>
            <p>
                <i>{error.statusText || error.message}</i>
            </p>
        </>

    );
}

export default ErrorPage;
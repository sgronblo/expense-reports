namespace ExpenseReports.Handlers

open System.IO
open Microsoft.AspNetCore.Http
open Giraffe.HttpHandlers
open Giraffe.Tasks

module ExpenseHandler =
    let newExpense (next : HttpFunc) (ctx : HttpContext) =
        task {
            return!
                (match ctx.Request.HasFormContentType with
                | false -> setStatusCode 400 >=> text "Bad request"
                | true ->
                    for file in ctx.Request.Form.Files do
                        let filePath = sprintf "receipts/%s" file.FileName
                        use stream = new FileStream(filePath, FileMode.Create)
                        file.CopyTo(stream)
                    text "Done") next ctx
        }

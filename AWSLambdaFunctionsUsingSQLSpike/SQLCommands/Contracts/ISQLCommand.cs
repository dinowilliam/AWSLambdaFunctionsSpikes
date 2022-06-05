namespace AWSLambdaFunctionsUsingSQLSpike.SQLCommands.Contracts {
    public interface ISQLCommand<T> {
        public List<T> Execute();
    }
}
